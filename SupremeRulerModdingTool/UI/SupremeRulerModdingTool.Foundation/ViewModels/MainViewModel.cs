using System.Windows.Forms;
using System.Windows.Input;
using MvpVmFramework.Core.Foundation;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _selectGamePathCommand;
        private ICommand _createNewUnitFileCommand;
        private ICommand _openExistingUnitFileCommand;
        private ICommand _saveSelectedTabCommand;
        private ICommand _closeTabCommand;
        private ICommand _selectedTabChangedCommand;
        private ICommand _keyPressCommand;

        private int _closeIndex;
        private int _selectedTabIndex;

        private KeyEventArgs _keyEventArgs;

        public ICommand SelectGamePathCommand
        {
            get
            {
                return _selectGamePathCommand;
            }

            set
            {
                if (_selectGamePathCommand != value)
                {
                    _selectGamePathCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand CreateNewUnitFileCommand
        {
            get
            {
                return _createNewUnitFileCommand;
            }

            set
            {
                if (_createNewUnitFileCommand != value)
                {
                    _createNewUnitFileCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand OpenExistingUnitFileCommand
        {
            get
            {
                return _openExistingUnitFileCommand;
            }

            set
            {
                if (_openExistingUnitFileCommand != value)
                {
                    _openExistingUnitFileCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand SaveSelectedTabCommand
        {
            get
            {
                return _saveSelectedTabCommand;
            }

            set
            {
                if (_saveSelectedTabCommand != value)
                {
                    _saveSelectedTabCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand CloseTabCommand
        {
            get
            {
                return _closeTabCommand;
            }

            set
            {
                if (_closeTabCommand != value)
                {
                    _closeTabCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand SelectedTabChangedCommand
        {
            get
            {
                return _selectedTabChangedCommand;
            }

            set
            {
                if (_selectedTabChangedCommand != value)
                {
                    _selectedTabChangedCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand KeyPressCommand
        {
            get
            {
                return _keyPressCommand;
            }

            set
            {
                if (_keyPressCommand != value)
                {
                    _keyPressCommand = value;
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

        // TODO : Abstract
        public KeyEventArgs KeyEventArgs
        {
            get
            {
                return _keyEventArgs;
            }

            set
            {
                _keyEventArgs = value;
                RaisePropertyChanged();
            }
        }
    }
}
