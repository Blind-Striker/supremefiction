using System;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using System.Windows.Input;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings
{
    public class TabChangedBinding : CommandBindingBase
    {
        private TabControl _tabControl;
        private Func<object> _commandParameterCallback;

        public TabChangedBinding(TabControl exitableTabControl, ICommand command, Func<object> commandParameterCallback)
            : base(exitableTabControl, command)
        {
            _tabControl = exitableTabControl;
            _commandParameterCallback = commandParameterCallback;
            _tabControl.SelectedIndexChanged += TabControlSelectedIndexChanged;
        }

        protected override void OnCommandCanExecuteChanged()
        {
            Command.CanExecute(_commandParameterCallback());
        }

        protected override void OnComponentDisposed()
        {
            _tabControl.SelectedIndexChanged -= TabControlSelectedIndexChanged;
            _tabControl = null;
            _commandParameterCallback = null;
        }

        private void TabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            Command.Execute(_commandParameterCallback());
        }
    }
}
