using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
        private readonly UnitEditorViewModel _unitEditorViewModel;
        private UnitFileHelper _fileHelper;
        private bool _preventEventFire;
        private int _lastLengthOfSearchText;

        public UnitEditorPresenter(IUnitEditorView view) : base(view)
        {
            _unitEditorViewModel = new UnitEditorViewModel();

            View.DataContext = _unitEditorViewModel;

            _unitEditorViewModel.PropertyChanged += UnitEditorViewModelPropertyChanged;
        }

        public void InitializeView(string path)
        {
            _fileHelper = new UnitFileHelper(path);

            IEnumerable<ComboboxItem> categoryList = UnitFileHelper.Categories.ToComboboxItems();

            var categories = new BindingList<ComboboxItem>(categoryList.ToList());

            ComboboxItem category = categories[0];

            _preventEventFire = true;

            _unitEditorViewModel.Categories = categories;
            _unitEditorViewModel.CurrentCategoryItemSelectedValue = category.ComboboxItemValueMember;

            OnCurrentCategoryItemChanged();
            
            _preventEventFire = false;
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
            if (_unitEditorViewModel.SearchText.Length >= 3 && _unitEditorViewModel.SearchText.Length > _lastLengthOfSearchText)
            {
                DataTable copyToDataTable = _unitEditorViewModel.ItemModels.AsEnumerable()
                    .Where(row =>
                            row["Name"].ToString()
                                .ToLowerInvariant()
                                .Contains(_unitEditorViewModel.SearchText.ToLowerInvariant()))
                    .CopyToDataTable();

                _unitEditorViewModel.ItemModels = copyToDataTable;
            }
            else if (_lastLengthOfSearchText > _unitEditorViewModel.SearchText.Length)
            {
                FillGrid();   
            }

            _lastLengthOfSearchText = _unitEditorViewModel.SearchText.Length;
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

            IList<ItemModel> itemModels = _fileHelper.GetItemModels(category, @class, subClass, searchText);

            DataTable dataTable = new DataTable();

            List<string> columns = new List<string>();
            if (!itemModels.IsNullOrEmpty())
            {
                columns = itemModels[0].Keys.Select(s => s).ToList();   
            }

            foreach (var column in columns)
            {
                dataTable.Columns.Add(new DataColumn(column));
            }

            foreach (var itemModel in itemModels)
            {
                DataRow dataRow = dataTable.NewRow();

                foreach (var key in itemModel.Keys)
                {
                    object value = itemModel[key];
                    dataRow[key] = value;
                }

                dataTable.Rows.Add(dataRow);
            }

            _unitEditorViewModel.ItemModels = dataTable;
        }
    }
}
