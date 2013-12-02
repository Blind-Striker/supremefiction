using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Waf.Applications;
using System.Waf.Applications.Services;

using MvpVmFramework.Core.Foundation;

using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Core.Presenters
{
    internal class MainPresenter : BasePresenter<IMainView, IMainPresenter>, IMainPresenter
    {
        private readonly IAppSettings _appSettings;
        private readonly IMessageService _messageService;
        private readonly IDialogService _dialogService;
        private readonly IPresenterFactory _presenterFactory;
        private readonly IUnitTabPageFactory _unitTabPageFactory;
        private readonly MainViewModel _mainViewModel;
        private string _mainFilesPath;
        private string _defaultUnitsFile;

        public MainPresenter(
            IMainView view, 
            IAppSettings appSettings, 
            IMessageService messageService,
            IDialogService dialogService,
            IPresenterFactory presenterFactory, 
            IUnitTabPageFactory unitTabPageFactory)
            : base(view)
        {
            _appSettings = appSettings;
            _messageService = messageService;
            _dialogService = dialogService;
            _presenterFactory = presenterFactory;
            _unitTabPageFactory = unitTabPageFactory;

            _mainViewModel = new MainViewModel
            {
                SelectGamePath = new DelegateCommand(ShowSelectGamePathView, CanShowSelectGamePathView),
                CreateNewUnitFile = new DelegateCommand(CreateNewUnitFile, CanCreateNewUnitFile),
                OpenExistingUnitFile = new DelegateCommand(OpenExistingUnitFile, CanOpenExistingUnitFile),
                SaveFiles = new DelegateCommand(SaveFiles, CanSaveFiles)
            };

            _mainViewModel.PropertyChanged += MainViewModelPropertyChanged;

            View.DataContext = _mainViewModel;

            if (_appSettings["GamePath"] == null)
            {
                ShowGamePathView();
            }
            else
            {
                SetGamePaths();
            }
        }

        private void ShowGamePathView()
        {
            ShowSelectGamePathView();
            SetGamePaths();
        }

        private void ShowSelectGamePathView()
        {
            var selectGamePathPresenter = _presenterFactory.CreatePresenter<ISelectGamePathPresenter>();

            selectGamePathPresenter.View.ShowDialog(View);
        }

        private void SetGamePaths()
        {
            if (_appSettings["GamePath"] != null)
            {
                string rootPath = _appSettings["GamePath"].ToString();
                _mainFilesPath = Path.Combine(rootPath, "Maps", "Data");
                _defaultUnitsFile = Path.Combine(_mainFilesPath, "DEFAULT.UNIT");

                if (!Directory.Exists(_mainFilesPath))
                {
                    _messageService.ShowError(View, "Data folder does not exist");
                    return;
                }

                if (!File.Exists(_defaultUnitsFile))
                {
                    _messageService.ShowError(View, "DEFAULT.UNIT file does not exist");
                    return;
                }
            }

            RaiseCanExecuteChanged(_mainViewModel.CreateNewUnitFile as DelegateCommand);
            RaiseCanExecuteChanged(_mainViewModel.OpenExistingUnitFile as DelegateCommand);
            RaiseCanExecuteChanged(_mainViewModel.SaveFiles as DelegateCommand);
        }

        private bool CanShowSelectGamePathView()
        {
            return true;
        }

        private void CreateNewUnitFile()
        {
            throw new System.NotImplementedException();
        }

        private bool CanCreateNewUnitFile()
        {
            return !_mainFilesPath.IsNullOrEmpty();
        }

        private void OpenExistingUnitFile()
        {
            string fileName = _dialogService.ShowFileDialog(this, "Unit File (*.UNIT)|*.UNIT|All files (*.*)|*.*");

            if (fileName.IsNullOrEmpty())
            {
                return;
            }

            var unitEditorPresenter = _presenterFactory.CreatePresenter<IUnitEditorPresenter>();
            IUnitTabPage unitTabPage = _unitTabPageFactory.CreateTabPage(unitEditorPresenter.View);
            unitTabPage.TabName = Path.GetFileNameWithoutExtension(fileName);

            unitEditorPresenter.InitializeView(fileName);

            View.AddTab(unitTabPage);
        }

        private bool CanOpenExistingUnitFile()
        {
            return !_mainFilesPath.IsNullOrEmpty();
        }

        private void SaveFiles()
        {
            throw new System.NotImplementedException();
        }

        private bool CanSaveFiles()
        {
            return !_mainFilesPath.IsNullOrEmpty();
        }

        private void MainViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
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
