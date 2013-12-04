using System.Collections.Generic;
using System.Windows;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IMainPresenter Presenter { get; set; }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public void AddTab(IUnitTabPage unitTabPage)
        {
        }

        public void RemoveAllTabs()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUnitTabPage> UnitTabPages { get; private set; }
        public void RemoveTab(IUnitTabPage unitTabPage)
        {
            throw new System.NotImplementedException();
        }
    }
}
