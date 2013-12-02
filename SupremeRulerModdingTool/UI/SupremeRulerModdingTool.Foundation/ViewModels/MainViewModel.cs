using System.Windows.Input;
using MvpVmFramework.Core.Foundation;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _selectGamePath;
        private ICommand _createNewUnitFile;
        private ICommand _openExistingUnitFile;
        private ICommand _saveFiles;
        private ICommand _closeTab;
        private ICommand _selectedTabChanged;

        private int _closeIndex;
        private int _selectedTabIndex;

        public ICommand SelectGamePath
        {
            get
            {
                return _selectGamePath;
            }

            set
            {
                if (_selectGamePath != value)
                {
                    _selectGamePath = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand CreateNewUnitFile
        {
            get
            {
                return _createNewUnitFile;
            }

            set
            {
                if (_createNewUnitFile != value)
                {
                    _createNewUnitFile = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand OpenExistingUnitFile
        {
            get
            {
                return _openExistingUnitFile;
            }

            set
            {
                if (_openExistingUnitFile != value)
                {
                    _openExistingUnitFile = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand SaveFiles
        {
            get
            {
                return _saveFiles;
            }

            set
            {
                if (_saveFiles != value)
                {
                    _saveFiles = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand CloseTab
        {
            get
            {
                return _closeTab;
            }

            set
            {
                if (_closeTab != value)
                {
                    _closeTab = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand SelectedTabChanged
        {
            get
            {
                return _selectedTabChanged;
            }

            set
            {
                if (_selectedTabChanged != value)
                {
                    _selectedTabChanged = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int CloseIndex
        {
            get
            {
                return _closeIndex;
            }

            set
            {
                _closeIndex = value;
                RaisePropertyChanged();
            }
        }

        public int SelectedTabIndex
        {
            get
            {
                return _selectedTabIndex;
            }

            set
            {
                _selectedTabIndex = value;
                RaisePropertyChanged();
            }
        }
    }
}
