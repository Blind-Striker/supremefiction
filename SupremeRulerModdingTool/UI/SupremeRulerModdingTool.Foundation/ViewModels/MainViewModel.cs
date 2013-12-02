using System.Windows.Input;
using MvpVmFramework.Core.Foundation;

namespace SupremeRulerModdingTool.Foundation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _selectGamePath;
        private ICommand _createNewUnitFile;
        private ICommand _openExistingUnitFile;
        private ICommand _saveFiles;

        public ICommand SelectGamePath
        {
            get { return _selectGamePath; }
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
            get { return _createNewUnitFile; }
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
            get { return _openExistingUnitFile; }
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
            get { return _saveFiles; }
            set
            {
                if (_saveFiles != value)
                {
                    _saveFiles = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
