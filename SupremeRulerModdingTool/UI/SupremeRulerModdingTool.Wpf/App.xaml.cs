using System.Windows;
using BootstrapperLibrary;
using MvpVmFramework.Core.Foundation;
using SupremeRulerModdingTool.Core;
using SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeRulerModdingTool.Wpf
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

            Window mainWindow = mainPresenter.View as Window;

            mainWindow.ShowDialog();
        }
    }
}
