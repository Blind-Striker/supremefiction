using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using MvpVmFramework.Core.Foundation;
using SupremeRulerModdingTool.Foundation;
using SupremeRulerModdingTool.Foundation.Presenters;
using SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.Core.Presenters
{
    internal class SelectGamePathPresenter : BasePresenter<ISelectGamePathView, ISelectGamePathPresenter>, ISelectGamePathPresenter
    {
        private readonly SelectGamePathViewModel _gamePathViewModel;

        private readonly IDialogService _dialogService;

        private readonly IMessageService _messageService;

        private readonly IAppSettings _settings;

        public SelectGamePathPresenter(
            ISelectGamePathView view, 
            IDialogService dialogService,
            IMessageService messageService, 
            IAppSettings settings)
            : base(view)
        {
            _dialogService = dialogService;
            _messageService = messageService;
            _settings = settings;

            _gamePathViewModel = new SelectGamePathViewModel();

            object settingValue = _settings["GamePath"];

            _gamePathViewModel.GamePath = settingValue != null
                ? settingValue.ToString()
                : string.Empty;

            _gamePathViewModel.Select = new DelegateCommand(Select, CanSelect);
            _gamePathViewModel.Cancel = new DelegateCommand(Cancel);
            _gamePathViewModel.Browse = new DelegateCommand(Browse);
            _gamePathViewModel.Search = new DelegateCommand(Search);

            View.DataContext = _gamePathViewModel;
        }

        private void Select()
        {
            _settings["GamePath"] = _gamePathViewModel.GamePath;

            _settings.Save();

            View.Close();
        }

        private bool CanSelect()
        {
            return !_gamePathViewModel.GamePath.IsNullOrEmpty() && Directory.Exists(_gamePathViewModel.GamePath);
        }

        private void Cancel()
        {
            View.Close();
        }

        private void Browse()
        {
            string selectedPath = _dialogService.ShowFolderDialog(View);

            if (!selectedPath.IsNullOrEmpty())
            {
                _gamePathViewModel.GamePath = selectedPath;
            }

            var delegateCommand = _gamePathViewModel.Select as DelegateCommand;
            if (delegateCommand != null)
            {
                delegateCommand.RaiseCanExecuteChanged();
            }
        }

        private void Search()
        {
            _messageService.ShowMessage("Soon...");
        }
    }
}
