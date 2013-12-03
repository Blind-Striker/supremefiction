using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MvpVmFramework.Core.Foundation;

using SupremeFiction.UI.SupremeRulerModdingTool.Core.Presenters;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Core
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IPresenterFactory>().AsFactory().LifestyleTransient(),
                Component.For<IMainPresenter>().ImplementedBy<MainPresenter>().LifestyleTransient(),
                Component.For<ISelectGamePathPresenter>().ImplementedBy<SelectGamePathPresenter>().LifestyleSingleton(),
                Component.For<IUnitEditorPresenter>().ImplementedBy<UnitEditorPresenter>().LifestyleTransient(),
                Component.For<IAppSettings>().ImplementedBy<IsolatedStorageAppSettings>().LifestyleSingleton(),
                Component.For<IRowContainer>().ImplementedBy<RowContainer>().LifestyleSingleton());
        }
    }
}
