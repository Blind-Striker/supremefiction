using System.Windows;
using SupremeRulerModdingTool.Foundation;
using SupremeRulerModdingTool.Foundation.Presenters;
using SupremeRulerModdingTool.Foundation.ViewModels;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.Wpf
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
        public void AddTab(IUnitTabPage unitTabPage)
        {
            throw new System.NotImplementedException();
        }

        private MainViewModel ViewModel { get { return DataContext as MainViewModel; } }
    }
}
