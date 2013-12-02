using System;
using System.Windows.Forms;
using SupremeFiction.UI.SupremeRulerModdingTool.Core;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public partial class MainForm : BaseForm, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public IMainPresenter Presenter { get; set; }

        public object DataContext
        {
            get
            {
                return dataContext.DataSource;
            }

            set
            {
                dataContext.DataSource = value;
            }
        }

        public void AddTab(IUnitTabPage unitTabPage)
        {
            filesTab.TabPages.Add(unitTabPage as TabPage);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var mainViewModel = DataContext as MainViewModel;

            if (mainViewModel == null)
            {
                return;
            }

            CommandAdapter.AddCommandBinding(selectGameToolStripMenuItem, mainViewModel.SelectGamePath);
            CommandAdapter.AddCommandBinding(createNewUnitFileToolStripMenuItem, mainViewModel.CreateNewUnitFile);
            CommandAdapter.AddCommandBinding(openExistingUnitFileToolStripMenuItem, mainViewModel.OpenExistingUnitFile);
            CommandAdapter.AddCommandBinding(saveFilesToolStripMenuItem, mainViewModel.SaveFiles);
        }
    }
}
