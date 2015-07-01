using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using System.Windows.Threading;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public partial class UnitEditorUserControl : UserControl, IUnitEditorView
    {
        private readonly CommandAdapter _commandAdapter;

        public UnitEditorUserControl()
        {
            InitializeComponent();
            Dispatcher.CurrentDispatcher.ShutdownStarted += CurrentDispatcher_ShutdownStarted;
            _commandAdapter = new CommandAdapter();
        }

        private void CurrentDispatcher_ShutdownStarted(object sender, EventArgs e)
        {
            DataContext = null;
        }

        public IUnitEditorPresenter Presenter { get; set; }

        public char PressedKey { get; set; }

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
        protected CommandAdapter CommandAdapter
        {
            get
            {
                return _commandAdapter;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var unitEditorViewModel = DataContext as UnitEditorViewModel;

            dataGridUnits.SelectionChanged += DataGridUnitsOnSelectionChanged;

            dataGridUnits.DataBindings.Add("DataSource", DataContext, "ItemModels", true, DataSourceUpdateMode.OnPropertyChanged);

            CommandAdapter.AddCommandBinding(copyRowsToolStripMenuItem, unitEditorViewModel.CopyRows);
            CommandAdapter.AddCommandBinding(deleteRowsToolStripMenuItem, unitEditorViewModel.DeleteRows);
            CommandAdapter.AddCommandBinding(pasteRowsToolStripMenuItem, unitEditorViewModel.PasteRows);
        }

        private void DataGridUnitsOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection = dataGridUnits.SelectedRows;

            List<DataRow> list = new List<DataRow>();

            foreach (DataGridViewRow dataGridViewRow in dataGridViewSelectedRowCollection)
            {
                DataRowView dataRow = dataGridViewRow.DataBoundItem as DataRowView;

                if (dataRow != null)
                {
                    list.Add(dataRow.Row);
                }
            }

            var unitEditorViewModel = DataContext as UnitEditorViewModel;

            unitEditorViewModel.SelectedRows = list;
        }
    }
}
