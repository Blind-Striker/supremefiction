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
using SupremeFiction.UI.SupremeRulerModdingTool.WinForm.HotKey;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public partial class MainForm : BaseForm, IMainView
    {
        private HotKeyManager hotKeyManager;

        private readonly LocalHotKey _copyHotKey = new LocalHotKey("Copy", Modifiers.Control, Keys.C);
        private readonly LocalHotKey _pasteHotKey = new LocalHotKey("Paste", Modifiers.Control, Keys.V);
        private readonly LocalHotKey _deleteHotKey = new LocalHotKey("Delete", Keys.Delete);
        public MainForm()
        {
            InitializeComponent();
            hotKeyManager = new HotKeyManager(this);
            hotKeyManager.AddLocalHotKey(_copyHotKey);
            hotKeyManager.AddLocalHotKey(_pasteHotKey);
            hotKeyManager.AddLocalHotKey(_deleteHotKey);

            hotKeyManager.LocalHotKeyPressed += HotKeyManagerLocalHotKeyPressed;
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
            var mainViewModel = DataContext as MainViewModel;

            filesTab.Location = new Point(4, 28);
            var tabPage = unitTabPage as TabPage;
            filesTab.TabPages.Add(tabPage);
            mainViewModel.SelectedTabIndex = filesTab.SelectedIndex;
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

            CommandAdapter.AddCommandBinding(hotKeyManager, mainViewModel.KeyPressCommand);

            filesTab.Identity = "ExitableTabControl";
            CommandAdapter.AddCommandBinding(filesTab, mainViewModel.CloseTabCommand, () => mainViewModel.CloseIndex = filesTab.SelectedIndex);
            filesTab.Identity = "TabControl";
            CommandAdapter.AddCommandBinding(filesTab, mainViewModel.SelectedTabChangedCommand, () => mainViewModel.SelectedTabIndex = filesTab.SelectedIndex);
        }

        private void HotKeyManagerLocalHotKeyPressed(object sender, LocalHotKeyEventArgs e)
        {
            var mainViewModel = DataContext as MainViewModel;

            Keys modiferKey = GetModiferKey(e.HotKey.Modifier);

            Keys keys = e.HotKey.Key | modiferKey;
            mainViewModel.KeyEventArgs = new KeyEventArgs(keys);
        }

        public static Keys GetModiferKey(Modifiers mod)
        {
            switch (mod)
            {
                case Modifiers.Control:
                    return Keys.Control;
                case Modifiers.Alt:
                    return Keys.Alt;
                case Modifiers.None:
                    return Keys.None;
                case Modifiers.Shift:
                    return Keys.Shift;
                case Modifiers.Win:
                    return Keys.LWin;
                default:
                    return Keys.None;
            }
        }
    }
}
