using System.Waf.Applications.Services;
using System.Waf.Presentation.WinForms.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvpVmFramework.Core.Foundation;
using MvpVmFramework.Core.Services;
using SupremeRulerModdingTool.Foundation;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.WinForm
{
    public class WinFormInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMainView>().ImplementedBy<MainForm>().LifestyleTransient(),
                Component.For<ISelectGamePathView>().ImplementedBy<SelectGamePathForm>().LifestyleTransient(),

                Component.For<IUnitEditorView>().ImplementedBy<UnitEditorUserControl>().LifestyleTransient(),

                Component.For<IMessageService>().ImplementedBy<MessageService>().LifestyleTransient(),
                Component.For<IDialogService>().ImplementedBy<WindowsFormDialogService>().LifestyleTransient(),

                Component.For<IUnitTabPageFactory>().ImplementedBy<UnitTabPageFactory>().LifestyleTransient()
                );
        }
    }
}
