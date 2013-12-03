using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using System.Windows.Input;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings
{
    public class KeyPressCommandBinding : CommandBindingBase
    {
        private ContainerControl _containerControl;
        private Func<object> _commandParameterCallback;

        public KeyPressCommandBinding(ContainerControl containerControl, ICommand command, Func<object> commandParameterCallback)
            : base(containerControl, command)
        {
            _containerControl = containerControl;
            _commandParameterCallback = commandParameterCallback;
            _containerControl.KeyPress += ContainerControlKeyPress;
        }

        protected override void OnCommandCanExecuteChanged()
        {
            Command.CanExecute(_commandParameterCallback());
        }

        protected override void OnComponentDisposed()
        {
            _containerControl.KeyPress -= ContainerControlKeyPress;
            _containerControl = null;
            _commandParameterCallback = null;
        }
        private void ContainerControlKeyPress(object sender, KeyPressEventArgs e)
        {
            Command.Execute(_commandParameterCallback);
        }
    }
}
