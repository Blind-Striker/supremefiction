using System.Waf.Applications.Services;
using System.Waf.Presentation.WinForms;
using System.Waf.Presentation.WinForms.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvpVmFramework.Core.Foundation;
using MvpVmFramework.Core.Services;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;
using SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandFactories;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public class WinFormInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            CommandAdapter.AddCommandBindingFactory(new ExitableTabControlCommandBindingFactory());
            CommandAdapter.AddCommandBindingFactory(new TabChangedCommandBindingFactory());
            CommandAdapter.AddCommandBindingFactory(new KeyPressCommandBindingFactory());

            container.Register(
                Component.For<IMainView>().ImplementedBy<MainForm>().LifestyleTransient(),
                Component.For<ISelectGamePathView>().ImplementedBy<SelectGamePathForm>().LifestyleTransient(),
                Component.For<IUnitEditorView>().ImplementedBy<UnitEditorUserControl>().LifestyleTransient(),
                Component.For<IMessageService>().ImplementedBy<MessageService>().LifestyleTransient(),
                Component.For<IDialogService>().ImplementedBy<WindowsFormDialogService>().LifestyleTransient(),
                Component.For<IUnitTabPageFactory>().ImplementedBy<UnitTabPageFactory>().LifestyleTransient(),
                Component.For<IPromptDialog>().ImplementedBy<WinFormPromptDialog>());
        }
    }
}
