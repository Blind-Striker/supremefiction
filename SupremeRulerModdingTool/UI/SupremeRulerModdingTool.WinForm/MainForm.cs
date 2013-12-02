using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public IEnumerable<IUnitTabPage> UnitTabPages
        {
            get
            {
                foreach (var tabPage in filesTab.TabPages)
                {
                    yield return tabPage as IUnitTabPage;
                }
            }
        }

        public void AddTab(IUnitTabPage unitTabPage)
        {
            filesTab.Location = new Point(4, 28);
            var tabPage = unitTabPage as TabPage;
            filesTab.TabPages.Add(tabPage);
        }

        public void RemoveTab(IUnitTabPage unitTabPage)
        {
            int indexOfTab = UnitTabPages.ToList().IndexOf(unitTabPage);

            filesTab.TabPages.RemoveAt(indexOfTab);
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

            filesTab.Identity = "ExitableTabControl";
            CommandAdapter.AddCommandBinding(filesTab, mainViewModel.CloseTab, () => mainViewModel.CloseIndex = filesTab.SelectedIndex);
            filesTab.Identity = "TabControl";
            CommandAdapter.AddCommandBinding(filesTab, mainViewModel.SelectedTabChanged, () => mainViewModel.SelectedTabIndex = filesTab.SelectedIndex);
        }
    }
}
