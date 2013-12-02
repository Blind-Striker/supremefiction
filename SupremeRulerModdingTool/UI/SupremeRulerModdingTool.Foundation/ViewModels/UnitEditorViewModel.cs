using System.ComponentModel;
using System.Data;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Models;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels
{
    public class UnitEditorViewModel : BaseViewModel
    {
        private string _currentCategoryItemSelectedValue;
        private string _currentClassItemSelectedValue;
        private string _currentSubClassItemSelectedValue;
        private string _searchText;

        private BindingList<ComboboxItem> _categories;
        private BindingList<ComboboxItem> _classes;
        private BindingList<ComboboxItem> _subClasses;

        private ComboboxItem _currentCategoryItem;
        private ComboboxItem _currentClassItem;
        private ComboboxItem _currentSubClassItem;

        private DataTable _itemModels;

        public string CurrentCategoryItemSelectedValue
        {
            get
            {
                return _currentCategoryItemSelectedValue;
            }

            set
            {
                bool changed = CheckPropertyChanged(_currentCategoryItemSelectedValue, value);

                if (changed)
                {
                    _currentCategoryItemSelectedValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ComboboxItem CurrentCategoryItem
        {
            get
            {
                return _currentCategoryItem;
            }

            set
            {
                bool changed = CheckPropertyChanged(_currentCategoryItem, value);

                if (changed)
                {
                    _currentCategoryItem = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string CurrentClassItemSelectedValue
        {
            get
            {
                return _currentClassItemSelectedValue;
            }

            set
            {
                bool changed = CheckPropertyChanged(_currentClassItemSelectedValue, value);

                if (changed)
                {
                    _currentClassItemSelectedValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ComboboxItem CurrentClassItem
        {
            get
            {
                return _currentClassItem;
            }

            set
            {
                bool changed = CheckPropertyChanged(_currentClassItem, value);

                if (changed)
                {
                    _currentClassItem = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string CurrentSubClassItemSelectedValue
        {
            get
            {
                return _currentSubClassItemSelectedValue;
            }

            set
            {
                bool changed = CheckPropertyChanged(_currentSubClassItemSelectedValue, value);

                if (changed)
                {
                    _currentSubClassItemSelectedValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ComboboxItem CurrentSubClassItem
        {
            get
            {
                return _currentSubClassItem;
            }

            set
            {
                bool changed = CheckPropertyChanged(_currentSubClassItem, value);

                if (changed)
                {
                    _currentSubClassItem = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }

            set
            {
                bool changed = CheckPropertyChanged(_searchText, value);

                if (changed)
                {
                    _searchText = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BindingList<ComboboxItem> Categories
        {
            get
            {
                return _categories;
            }

            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BindingList<ComboboxItem> Classes
        {
            get
            {
                return _classes;
            }

            set
            {
                if (_classes != value)
                {
                    _classes = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BindingList<ComboboxItem> SubClasses
        {
            get
            {
                return _subClasses;
            }

            set
            {
                if (_subClasses != value)
                {
                    _subClasses = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DataTable ItemModels
        {
            get
            {
                return _itemModels;
            }

            set
            {
                if (_itemModels != value)
                {
                    _itemModels = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool CheckPropertyChanged<T>(T oldValue, T newValue)
        {
            if (oldValue == null && newValue == null)
            {
                return false;
            }

            if ((oldValue == null && newValue != null) || (oldValue != null && newValue == null) || !oldValue.Equals(newValue))
            {
                return true;
            }

            return false;
        }
    }
}
