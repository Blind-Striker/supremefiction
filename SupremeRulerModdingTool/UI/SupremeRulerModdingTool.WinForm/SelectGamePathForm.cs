using System;
using SupremeFiction.UI.SupremeRulerModdingTool.Core;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public partial class SelectGamePathForm : BaseForm, ISelectGamePathView
    {
        public SelectGamePathForm()
        {
            InitializeComponent();
        }

        public object DataContext
        {
            get { return dataContext.DataSource; }
            set { dataContext.DataSource = value; }
        }

        public ISelectGamePathPresenter Presenter { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var gamePathViewModel = DataContext as SelectGamePathViewModel;

            CommandAdapter.AddCommandBinding(btnSelect, gamePathViewModel.Select);
            CommandAdapter.AddCommandBinding(btnCancel, gamePathViewModel.Cancel);
            CommandAdapter.AddCommandBinding(btnBrowse, gamePathViewModel.Browse);
            CommandAdapter.AddCommandBinding(btnSearch, gamePathViewModel.Search);
        }
    }
}
