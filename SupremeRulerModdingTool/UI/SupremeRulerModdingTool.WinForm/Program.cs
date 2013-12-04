using System;
using System.Text;
using System.Waf.Applications.Services;
using System.Windows.Forms;
using Castle.Core.Internal;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.DependencyInjection.BootstrapperLibrary;
using SupremeFiction.UI.SupremeRulerModdingTool.Core;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    internal static class Program
    {
        private static Bootstrapper _bootstrapper;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _bootstrapper = Bootstrapper.Create()
                .RegisterInstaller(new WinFormInstaller())
                .RegisterInstaller(new CoreInstaller());

            var presenterFactory = _bootstrapper.WindsorContainer.Resolve<IPresenterFactory>();
            var mainPresenter = presenterFactory.CreatePresenter<IMainPresenter>();

            Application.Run(mainPresenter.View as Form);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            IMessageService messageService = _bootstrapper.WindsorContainer.Resolve<IMessageService>();
            object form = !Application.OpenForms.IsNullOrEmpty() ? Application.OpenForms[0] : null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("An error occured");

            Exception exception = e.ExceptionObject as Exception;

            while (exception != null)
            {
                sb.AppendLine(exception.Message);
                sb.AppendLine("Inner :");

                exception = exception.InnerException;
            }

            messageService.ShowError(form, sb.ToString());
        }
    }
}
