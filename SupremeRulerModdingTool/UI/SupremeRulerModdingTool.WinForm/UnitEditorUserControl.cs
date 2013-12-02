using System;
using System.ComponentModel;
using System.Windows.Forms;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public partial class UnitEditorUserControl : UserControl, IUnitEditorView
    {
        public UnitEditorUserControl()
        {
            InitializeComponent();
        }

        public IUnitEditorPresenter Presenter { get; set; }

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var unitEditorViewModel = ReBindGrid();

            unitEditorViewModel.PropertyChanged += UnitEditorViewModelPropertyChanged;
        }

        private void UnitEditorViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ItemModels")
            {
                ReBindGrid();
            }
        }

        private UnitEditorViewModel ReBindGrid()
        {
            var unitEditorViewModel = DataContext as UnitEditorViewModel;

            dataGridUnits.DataSource = unitEditorViewModel.ItemModels;
            return unitEditorViewModel;
        }
    }
}
