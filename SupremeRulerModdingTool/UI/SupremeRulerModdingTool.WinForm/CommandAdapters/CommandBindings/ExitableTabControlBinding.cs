using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Presentation.WinForms;
using System.Windows.Input;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings
{
    public class ExitableTabControlBinding : CommandBindingBase
    {
        private ExitableTabControl _exitableTabControl;
        private Func<object> _commandParameterCallback;

        public ExitableTabControlBinding(ExitableTabControl exitableTabControl, ICommand command, Func<object> commandParameterCallback)
            : base(exitableTabControl, command)
        {
            _exitableTabControl = exitableTabControl;
            _commandParameterCallback = commandParameterCallback;
            _exitableTabControl.OnClose += ExitableTabControlOnClose;
        }

        protected override void OnCommandCanExecuteChanged()
        {
            Command.CanExecute(_commandParameterCallback());
        }

        protected override void OnComponentDisposed()
        {
            _exitableTabControl.OnClose -= ExitableTabControlOnClose;
            _exitableTabControl = null;
            _commandParameterCallback = null;
        }

        private void ExitableTabControlOnClose(object sender, CloseEventArgs e)
        {
            Command.Execute(_commandParameterCallback());
        }
    }
}
