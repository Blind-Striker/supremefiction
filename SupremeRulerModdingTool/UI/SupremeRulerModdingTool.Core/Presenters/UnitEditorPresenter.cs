using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using Castle.Core.Internal;
using CodeFiction.DarkMatterFramework.Libraries.IOLibrary;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Models;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Core.Presenters
{
    internal class UnitEditorPresenter : BasePresenter<IUnitEditorView, IUnitEditorPresenter>, IUnitEditorPresenter
    {
        private readonly IMessageService _messageService;
        private readonly IRowContainer _rowContainer;
        private readonly Dictionary<string, DataTable> _dataTablesByCategory;

        private UnitEditorViewModel _unitEditorViewModel;
        private UnitFileHelper _fileHelper;

        private bool _preventEventFire;
        private bool _isDirty;

        public UnitEditorPresenter(IUnitEditorView view, IMessageService messageService, IRowContainer rowContainer) 
            : base(view)
        {
            _messageService = messageService;
            _rowContainer = rowContainer;
            _dataTablesByCategory = new Dictionary<string, DataTable>();
            _unitEditorViewModel = new UnitEditorViewModel()
            {
                DeleteRows = new DelegateCommand(DeleteRows),
                CopyRows = new DelegateCommand(CopyRows),
                PasteRows = new DelegateCommand(PasteRows, CanPasteRows)
            };

            View.DataContext = _unitEditorViewModel;

            _unitEditorViewModel.PropertyChanged += UnitEditorViewModelPropertyChanged;
            _rowContainer.RowCopied += RowContainerOnRowCopied;
        }

        public IUnitTabPage UnitTabPage { get; set; }

        public bool IsDirty
        {
            get { return _isDirty; }
        }

        private string UnitPath { get; set; }

        public string Name { get; set; }

        public void InitializeView(string path)
        {
            _preventEventFire = true;

            _isDirty = false;
            UnitPath = path;
            Name = Path.GetFileNameWithoutExtension(path);
            UnitTabPage.TabName = Name;

            _fileHelper = new UnitFileHelper(path);

            List<string> categories = UnitFileHelper.Categories.ToList();
            IEnumerable<ComboboxItem> categoryList = categories.ToComboboxItems();

            var categoryBindingList = new BindingList<ComboboxItem>(categoryList.ToList());

            _unitEditorViewModel.Categories = categoryBindingList;
            _unitEditorViewModel.CurrentCategoryItemSelectedValue = categoryBindingList[0].ComboboxItemValueMember;

            SetDataTables(categories);

            OnCurrentCategoryItemChanged();
            
            _preventEventFire = false;
        }

        public void Save()
        {
            var rowBuilder = new StringBuilder();

            string fileName = Path.GetFileNameWithoutExtension(UnitPath);
            string extension = Path.GetExtension(UnitPath);
            string directoryName = Path.GetDirectoryName(UnitPath);

            string newFileName = string.Format("{0}-{1}{2}", fileName, DateTime.Now.ToString("yyyyMdhhmmss"), extension);
            string newFilePath = Path.Combine(directoryName, newFileName);

            string readFile = IoHelper.ReadFile(UnitPath);

            using (StringReader reader = new StringReader(readFile))
            {
                for (int i = 0; i < 5; i++)
                {
                    string line = reader.ReadLine();
                    rowBuilder.AppendLine(line);
                }
            }

            if (!_dataTablesByCategory.IsNullOrEmpty())
            {
                foreach (var keyValue in _dataTablesByCategory)
                {
                    keyValue.Value.AsEnumerable().ForEach(row => rowBuilder.AppendLine(row.ItemArray.JoinToString(",")));
                }
            }

            string content = rowBuilder.ToString();

            IoHelper.CreateFile(newFilePath, content);

            _messageService.ShowMessage(View, string.Format("File Successfully Saved To {0}", newFilePath));

            InitializeView(newFilePath);
        }

        public void Dispose()
        {
            _unitEditorViewModel.PropertyChanged -= UnitEditorViewModelPropertyChanged;
            _rowContainer.RowCopied -= RowContainerOnRowCopied;

            _preventEventFire = true;
            _unitEditorViewModel = null;
            _fileHelper = null;
            _preventEventFire = false;
        }

        private void DeleteRows()
        {
            bool yes = _messageService.ShowYesNoQuestion(View, "Are You Sure You Want To Delete Delected Rows?");

            if (!yes)
            {
                return;
            }

            IList<DataRow> selectedRows = _unitEditorViewModel.SelectedRows;

            foreach (DataRow selectedRow in selectedRows)
            {
                selectedRow.Delete();
            }
        }

        private void CopyRows()
        {
            string category = _unitEditorViewModel.CurrentCategoryItemSelectedValue;
            IList<DataRow> selectedRows = _unitEditorViewModel.SelectedRows;
            IList<DataRow> clonedRows = new List<DataRow>();

            _preventEventFire = true;
            foreach (DataRow selectedRow in selectedRows)
            {
                DataRow cloneRow = _unitEditorViewModel.ItemModels.NewRow();
                cloneRow.ItemArray = (object[])selectedRow.ItemArray.Clone();
                clonedRows.Add(cloneRow);
            }

            _preventEventFire = false;

            _rowContainer.Set(category, selectedRows);

            _messageService.ShowMessage(View, "Selected Rows Copied Successfully");
        }

        private void PasteRows()
        {
            KeyValuePair<string, IList<DataRow>>? keyValuePair = _rowContainer.Get();
            if (keyValuePair.HasValue)
            {
                string key = keyValuePair.Value.Key;
                IList<DataRow> dataRows = keyValuePair.Value.Value;

                DataTable dataTable = _dataTablesByCategory[key];

                foreach (DataRow dataRow in dataRows)
                {
                    dataTable.ImportRow(dataRow);
                }
            }
        }

        private bool CanPasteRows()
        {
            return _rowContainer.Get().HasValue;
        }

        private void SetDataTables(IEnumerable<string> categories)
        {
            _dataTablesByCategory.Clear();

            foreach (var category in categories)
            {
                DataTable dataTable = new DataTable();

                IList<ItemModel> items = _fileHelper.GetItemModels(category, null, null, null);

                foreach (var column in items[0].Keys)
                {
                    dataTable.Columns.Add(new DataColumn(column));
                }

                foreach (var itemModel in items)
                {
                    DataRow dataRow = dataTable.NewRow();

                    foreach (var key in itemModel.Keys)
                    {
                        object value = itemModel[key];
                        dataRow[key] = value;
                    }

                    dataTable.Rows.Add(dataRow);
                }

                if (dataTable.Rows.Count > 0)
                {
                    dataTable.RowChanged += SetDirty;
                    dataTable.RowDeleted += SetDirty;
                    dataTable.TableNewRow += SetDirty;
                }

                _dataTablesByCategory.Add(category, dataTable);
            }
        }

        private void UnitEditorViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;

            if ((propertyName != "CurrentCategoryItemSelectedValue" &&
                propertyName != "CurrentClassItemSelectedValue" &&
                propertyName != "CurrentSubClassItemSelectedValue" &&
                propertyName != "SearchText") || _preventEventFire)
            {
                return;
            }

            if (propertyName == "CurrentCategoryItemSelectedValue")
            {
                OnCurrentCategoryItemChanged();
            }

            if (propertyName == "CurrentClassItemSelectedValue")
            {
                OnCurrentClassItemChanged();
            }

            if (propertyName == "CurrentSubClassItemSelectedValue")
            {
                OnCurrentSubClassItemChanged();
            }

            if (propertyName == "SearchText")
            {
                OnSearchTextChanged();
            }
        }

        private void OnCurrentCategoryItemChanged()
        {
            _preventEventFire = true;
            _unitEditorViewModel.Classes = new BindingList<ComboboxItem>();
            _unitEditorViewModel.SubClasses = new BindingList<ComboboxItem>();
            string currentCategory = _unitEditorViewModel.CurrentCategoryItemSelectedValue;

            IEnumerable<ComboboxItem> comboboxItems = UnitFileHelper.GetClasses(currentCategory).ToComboboxItems();

            var classes = new BindingList<ComboboxItem>(comboboxItems.ToList());
            classes.Insert(0, new ComboboxItem { ComboboxItemDisplayMember = "Select", ComboboxItemValueMember = "Select" });

            ComboboxItem selectedItem = _unitEditorViewModel.Categories.FirstOrDefault(item => item.ComboboxItemValueMember == _unitEditorViewModel.CurrentCategoryItemSelectedValue);

            _unitEditorViewModel.CurrentCategoryItem = selectedItem;

            _unitEditorViewModel.Classes = classes;
            _unitEditorViewModel.CurrentClassItemSelectedValue = "Select";
            
            FillGrid();

            _preventEventFire = false;
        }

        private void OnCurrentClassItemChanged()
        {
            _preventEventFire = true;
            _unitEditorViewModel.SubClasses = new BindingList<ComboboxItem>();

            if (!_unitEditorViewModel.CurrentClassItemSelectedValue.IsNullOrEmpty())
            {
                if (_unitEditorViewModel.CurrentClassItemSelectedValue != "Select")
                {
                    string @class = _unitEditorViewModel.CurrentClassItemSelectedValue;
                    IEnumerable<ComboboxItem> comboboxItems = UnitFileHelper.GetSubClasses(@class).ToComboboxItems();

                    var subClasses = new BindingList<ComboboxItem>(comboboxItems.ToList());
                    subClasses.Insert(0, new ComboboxItem { ComboboxItemDisplayMember = "Select", ComboboxItemValueMember = "Select" });

                    _unitEditorViewModel.SubClasses = subClasses;
                    _unitEditorViewModel.CurrentSubClassItemSelectedValue = "Select";
                }

                ComboboxItem selectedItem = _unitEditorViewModel.Classes.FirstOrDefault(item => item.ComboboxItemValueMember == _unitEditorViewModel.CurrentClassItemSelectedValue);

                _unitEditorViewModel.CurrentClassItem = selectedItem;
            }

            FillGrid();

            _preventEventFire = false;
        }

        private void OnCurrentSubClassItemChanged()
        {
            if (!_unitEditorViewModel.CurrentSubClassItemSelectedValue.IsNullOrEmpty())
            {
                ComboboxItem selectedItem = _unitEditorViewModel.SubClasses.FirstOrDefault(item => item.ComboboxItemValueMember == _unitEditorViewModel.CurrentSubClassItemSelectedValue);
                _unitEditorViewModel.CurrentSubClassItem = selectedItem;
            }

            FillGrid();
        }

        private void OnSearchTextChanged()
        {
            FillGrid();
        }

        private void FillGrid()
        {
            string category = _unitEditorViewModel.CurrentCategoryItemSelectedValue;
            string @class = _unitEditorViewModel.CurrentClassItemSelectedValue == "Select"
                ? null
                : _unitEditorViewModel.CurrentClassItemSelectedValue;

            string subClass = _unitEditorViewModel.CurrentSubClassItemSelectedValue == "Select"
                ? null
                : _unitEditorViewModel.CurrentSubClassItemSelectedValue;

            string searchText = !_unitEditorViewModel.SearchText.IsNullOrEmpty() && _unitEditorViewModel.SearchText.Length < 3 ? null : _unitEditorViewModel.SearchText;

            DataTable dataTable = _dataTablesByCategory[category];
            dataTable.CaseSensitive = false;
            _unitEditorViewModel.ItemModels = dataTable;

            string query = QueryBuilder(category, @class, subClass, searchText);

            _unitEditorViewModel.ItemModels.DefaultView.RowFilter = query;
        }

        private string QueryBuilder(string category, string className, string subClassName, string searchText)
        {
            List<int> unitClasses = _fileHelper.GetUnitClasses(category, className, subClassName);

            string unitClassQuery = null;
            string searchQuery = null;
            string query;

            if (!unitClasses.IsNullOrEmpty())
            {
                string unitClassesString = unitClasses.JoinToString(",");
                unitClassQuery = string.Format("[Unit Class] IN ({0})", unitClassesString);
            }

            if (!searchText.IsNullOrEmpty())
            {
                searchQuery = string.Format("[Name] LIKE '%{0}%'", searchText.ToLower());
            }

            if (!unitClassQuery.IsNullOrEmpty() && !searchQuery.IsNullOrEmpty())
            {
                query = string.Format("{0} AND {1}", unitClassQuery, searchQuery);
            }
            else if (!unitClassQuery.IsNullOrEmpty() && searchQuery.IsNullOrEmpty())
            {
                query = unitClassQuery;
            }
            else
            {
                query = searchQuery;
            }

            return query;
        }

        private void RowContainerOnRowCopied(object sender, EventArgs eventArgs)
        {
            if (_unitEditorViewModel != null)
            {
                RaiseCanExecuteChanged(_unitEditorViewModel.PasteRows as DelegateCommand);
            }
        }

        private void SetDirty(object sender, object args)
        {
            if (!_isDirty && !_preventEventFire)
            {
                _isDirty = true;
                UnitTabPage.TabName = string.Format("{0} *", Name);
            }
        }

        private void RaiseCanExecuteChanged(DelegateCommand delegateCommand)
        {
            if (delegateCommand != null)
            {
                delegateCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
