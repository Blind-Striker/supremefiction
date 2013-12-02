using System.Waf.Applications.Services;
using System.Waf.Presentation.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvpVmFramework.Core.Foundation;
using MvpVmFramework.Core.Services;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Wpf
{
    class WpfInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMainView>().ImplementedBy<MainWindow>().LifestyleTransient(),


                Component.For<IMessageService>().ImplementedBy<MessageService>().LifestyleTransient(),
                Component.For<IDialogService>().ImplementedBy<WpfFormDialogService>().LifestyleTransient());
        }
    }
}
