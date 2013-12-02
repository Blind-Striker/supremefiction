using System;
using System.Windows.Forms;
using BootstrapperLibrary;
using MvpVmFramework.Core.Foundation;
using SupremeRulerModdingTool.Core;
using SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeRulerModdingTool.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
