using System;
using System.Windows.Forms;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.DependencyInjection.BootstrapperLibrary;
using SupremeFiction.UI.SupremeRulerModdingTool.Core;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstrapper registerInstaller = Bootstrapper.Create()
                .RegisterInstaller(new WinFormInstaller())
                .RegisterInstaller(new CoreInstaller());

            var presenterFactory = registerInstaller.WindsorContainer.Resolve<IPresenterFactory>();
            var mainPresenter = presenterFactory.CreatePresenter<IMainPresenter>();

            Application.Run(mainPresenter.View as Form);
        }
    }
}
