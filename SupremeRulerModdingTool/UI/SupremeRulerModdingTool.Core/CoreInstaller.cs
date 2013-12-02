using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MvpVmFramework.Core.Foundation;

using SupremeRulerModdingTool.Core.Presenters;
using SupremeRulerModdingTool.Foundation;
using SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeRulerModdingTool.Core
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
                

                Component.For<IAppSettings>().ImplementedBy<IsolatedStorageAppSettings>().LifestyleSingleton());
        }
    }
}
