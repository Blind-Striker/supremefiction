using System.Windows;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.DependencyInjection.BootstrapperLibrary;
using SupremeFiction.UI.SupremeRulerModdingTool.Core;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrapper registerInstaller = Bootstrapper.Create()
                .RegisterInstaller(new WpfInstaller())
                .RegisterInstaller(new CoreInstaller());

            var presenterFactory = registerInstaller.WindsorContainer.Resolve<IPresenterFactory>();
            var mainPresenter = presenterFactory.CreatePresenter<IMainPresenter>();

            var mainWindow = mainPresenter.View as Window;

            mainWindow.ShowDialog();
        }
    }
}
