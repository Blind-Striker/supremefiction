using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupremeRulerModdingTool.Foundation.Presenters;
using SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.WinForm
{
    public partial class UnitEditorUserControl : UserControl, IUnitEditorView
    {
        public UnitEditorUserControl()
        {
            InitializeComponent();
        }

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
            UnitEditorViewModel unitEditorViewModel = DataContext as UnitEditorViewModel;

            dataGridUnits.DataSource = unitEditorViewModel.ItemModels;
            return unitEditorViewModel;
        }

        public IUnitEditorPresenter Presenter { get; set; }
    }
}
