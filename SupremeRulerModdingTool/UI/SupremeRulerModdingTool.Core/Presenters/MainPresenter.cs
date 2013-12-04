using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using System.Windows.Forms;
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
        private readonly IPromptDialog _promptDialog;
        private readonly IPresenterFactory _presenterFactory;
        private readonly IUnitTabPageFactory _unitTabPageFactory;
        private readonly MainViewModel _mainViewModel;

        private readonly List<IUnitEditorPresenter> _unitEditorPresenters;

        private readonly Container _container;

        private string _mainFilesPath;
        private string _defaultUnitsFile;

        public MainPresenter(
            IMainView view, 
            IAppSettings appSettings, 
            IMessageService messageService,
            IDialogService dialogService,
            IPromptDialog promptDialog,
            IPresenterFactory presenterFactory, 
            IUnitTabPageFactory unitTabPageFactory)
            : base(view)
        {
            _container = new Container();
            _appSettings = appSettings;
            _messageService = messageService;
            _dialogService = dialogService;
            _promptDialog = promptDialog;
            _presenterFactory = presenterFactory;
            _unitTabPageFactory = unitTabPageFactory;

            _unitEditorPresenters = new List<IUnitEditorPresenter>();

            _mainViewModel = new MainViewModel
            {
                SelectGamePathCommand = new DelegateCommand(OnSelectGamePath, CanSelectGamePath),
                CreateNewUnitFileCommand = new DelegateCommand(OnCreateNewUnitFile, CanCreateNewUnitFile),
                OpenExistingUnitFileCommand = new DelegateCommand(OnOpenExistingUnitFile, CanOpenExistingUnitFile),
                SaveSelectedTabCommand = new DelegateCommand(OnSaveFiles, CanSaveFiles),
                CloseTabCommand = new DelegateCommand(OnCloseTab, CanCloseTab),
                SelectedTabChangedCommand = new DelegateCommand(OnSelectedTabChanged, CanSelectedTabChanged),
                KeyPressCommand = new DelegateCommand(OnKeyPress, CanKeyPress)
            };

            _mainViewModel.PropertyChanged += MainViewModelPropertyChanged;

            View.DataContext = _mainViewModel;

            if (_appSettings["GamePath"] == null)
            {
                OnSelectGamePath();
            }
            else
            {
                SetGamePaths();
            }
        }

        private void OnSelectGamePath()
        {
            var selectGamePathPresenter = _presenterFactory.CreatePresenter<ISelectGamePathPresenter>();

            selectGamePathPresenter.View.ShowDialog(View);

            bool hasDirtyTabs = CheckDirtyTabs();

            if (hasDirtyTabs)
            {
                string message = string.Format("There are unsaved changes in pages. Do you really want to close all Pages");

                bool yes = _messageService.ShowYesNoQuestion(View, message);

                if (yes)
                {
                    CloseAllTabs();
                }
            }

            SetGamePaths();
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

            RaiseCanExecuteChanged(_mainViewModel.CreateNewUnitFileCommand as DelegateCommand);
            RaiseCanExecuteChanged(_mainViewModel.OpenExistingUnitFileCommand as DelegateCommand);
            RaiseCanExecuteChanged(_mainViewModel.SaveSelectedTabCommand as DelegateCommand);
        }

        private bool CanSelectGamePath()
        {
            return true;
        }

        private void OnCreateNewUnitFile()
        {
            string fileName = _promptDialog.ShowDialog("File Name", "Please Enter File Name");

            if (EnumerableExtensions.IsNullOrEmpty(fileName))
            {
                return;
            }

            IUnitEditorPresenter presenter = CreateNewTab();
            presenter.InitializeNewView(fileName);
        }

        private bool CanCreateNewUnitFile()
        {
            return !EnumerableExtensions.IsNullOrEmpty(_mainFilesPath);
        }

        private void OnOpenExistingUnitFile()
        {
            string filePath = _dialogService.ShowFileDialog(this, "Unit File (*.UNIT)|*.UNIT|All files (*.*)|*.*");

            if (EnumerableExtensions.IsNullOrEmpty(filePath))
            {
                return;
            }

            IUnitEditorPresenter presenter = CreateNewTab();
            presenter.PrepForUpdate(filePath);
        }

        private bool CanOpenExistingUnitFile()
        {
            return !EnumerableExtensions.IsNullOrEmpty(_mainFilesPath);
        }

        private void OnSaveFiles()
        {            
            int selectedTabIndex = _mainViewModel.SelectedTabIndex;

            if (selectedTabIndex < 0)
            {
                return;
            }

            IUnitEditorPresenter unitEditorPresenter = _unitEditorPresenters[selectedTabIndex];

            unitEditorPresenter.Save();
        }

        private bool CanSaveFiles()
        {
            List<IUnitTabPage> unitTabPages = View.UnitTabPages.ToList();

            return !EnumerableExtensions.IsNullOrEmpty(_mainFilesPath) && unitTabPages.Count > 0;
        }

        private void OnCloseTab()
        {
            int closeIndex = _mainViewModel.CloseIndex;
            CloseTab(closeIndex);
        }

        private bool CanCloseTab()
        {
            return true;
        }

        private void OnSelectedTabChanged()
        {
            RaiseCanExecuteChanged(_mainViewModel.SaveSelectedTabCommand as DelegateCommand);
        }

        private bool CanSelectedTabChanged()
        {
            return true;
        }

        private void OnKeyPress()
        {
            KeyEventArgs keyEventArgs = _mainViewModel.KeyEventArgs;
            int selectedTabIndex = _mainViewModel.SelectedTabIndex;

            if (_unitEditorPresenters.IsNullOrEmpty())
            {
                return;
            }

            IUnitEditorPresenter unitEditorPresenter = _unitEditorPresenters[selectedTabIndex];

            if(keyEventArgs.KeyData == (Keys.Control | Keys.C))
            {
                unitEditorPresenter.CopyRows();
            }

            if (keyEventArgs.KeyData == (Keys.Control | Keys.V))
            {
                unitEditorPresenter.PasteRows();
            }

            if (keyEventArgs.KeyCode == Keys.Delete)
            {
                unitEditorPresenter.DeleteRows();
            }
        }

        private bool CanKeyPress()
        {
            return true;
        }

        private void MainViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        private IUnitEditorPresenter CreateNewTab()
        {
            var unitEditorPresenter = _presenterFactory.CreatePresenter<IUnitEditorPresenter>();
            IUnitTabPage unitTabPage = _unitTabPageFactory.CreateTabPage(unitEditorPresenter.View, _container);
            unitEditorPresenter.UnitTabPage = unitTabPage;

            _unitEditorPresenters.Add(unitEditorPresenter);
            View.AddTab(unitTabPage);
            OnSelectedTabChanged();

            return unitEditorPresenter;
        }

        private void CloseTab(int closeIndex)
        {
            List<IUnitTabPage> unitTabPages = View.UnitTabPages.ToList();

            IUnitEditorPresenter unitEditorPresenter = _unitEditorPresenters[closeIndex];
            IUnitTabPage unitTabPage = unitTabPages[closeIndex];

            if (unitEditorPresenter.IsDirty)
            {
                string message = string.Format("There are unsaved changes. Do you really want to close {0} Page", unitEditorPresenter.Name);

                bool yes = _messageService.ShowYesNoQuestion(View, message);

                if (!yes)
                {
                    return;
                }
            }

            View.RemoveTab(unitTabPage);
            _unitEditorPresenters.RemoveAt(closeIndex);
            unitEditorPresenter.Dispose();

            RaiseCanExecuteChanged(_mainViewModel.SaveSelectedTabCommand as DelegateCommand);
        }

        private bool CheckDirtyTabs()
        {
            if (_unitEditorPresenters.IsNullOrEmpty())
            {
                return false;
            }

            return _unitEditorPresenters.Any(presenter => presenter.IsDirty);
        }

        private void CloseAllTabs()
        {
            if (_unitEditorPresenters.IsNullOrEmpty())
            {
                return;
            }

            _unitEditorPresenters.ForEach(presenter => presenter.Dispose());
            _unitEditorPresenters.Clear();
            View.RemoveAllTabs();
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
