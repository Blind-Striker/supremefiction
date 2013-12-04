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

        public void RemoveAllTabs()
        {
            filesTab.TabPages.Clear();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var mainViewModel = DataContext as MainViewModel;

            if (mainViewModel == null)
            {
                return;
            }

            CommandAdapter.AddCommandBinding(selectGameToolStripMenuItem, mainViewModel.SelectGamePathCommand);
            CommandAdapter.AddCommandBinding(newUnitFileToolStripMenuItem, mainViewModel.CreateNewUnitFileCommand);
            CommandAdapter.AddCommandBinding(openUnitFileToolStripMenuItem, mainViewModel.OpenExistingUnitFileCommand);
            CommandAdapter.AddCommandBinding(saveUnitFileToolStripMenuItem, mainViewModel.SaveSelectedTabCommand);

            CommandAdapter.AddCommandBinding(this, mainViewModel.KeyPressCommand);

            filesTab.Identity = "ExitableTabControl";
            CommandAdapter.AddCommandBinding(filesTab, mainViewModel.CloseTabCommand, () => mainViewModel.CloseIndex = filesTab.SelectedIndex);
            filesTab.Identity = "TabControl";
            CommandAdapter.AddCommandBinding(filesTab, mainViewModel.SelectedTabChangedCommand, () => mainViewModel.SelectedTabIndex = filesTab.SelectedIndex);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            var mainViewModel = DataContext as MainViewModel;
            mainViewModel.KeyEventArgs = e;
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (msg.Msg)
        //    {
        //        case 0x100:
        //        case 0x104:
        //            switch (keyData)
        //            {
        //                case Keys.Control | Keys.C:
        //                    MessageBox.Show("Ctrl + C pressed");
        //                    break;
        //            }
        //            break;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}
