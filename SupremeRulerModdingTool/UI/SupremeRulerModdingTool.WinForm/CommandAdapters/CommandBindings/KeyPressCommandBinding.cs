using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using System.Windows.Input;
using SupremeFiction.UI.SupremeRulerModdingTool.WinForm.HotKey;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings
{
    public class KeyPressCommandBinding : CommandBindingBase
    {
        private HotKeyManager _hotKeyManager;
        private Func<object> _commandParameterCallback;

        public KeyPressCommandBinding(HotKeyManager hotKeyManager, ICommand command, Func<object> commandParameterCallback)
            : base(hotKeyManager, command)
        {
            _hotKeyManager = hotKeyManager;
            _commandParameterCallback = commandParameterCallback;
            _hotKeyManager.LocalHotKeyPressed += HotKeyManagerOnLocalHotKeyPressed;
        }

        protected override void OnCommandCanExecuteChanged()
        {
            Command.CanExecute(_commandParameterCallback());
        }

        protected override void OnComponentDisposed()
        {
            _hotKeyManager.LocalHotKeyPressed -= HotKeyManagerOnLocalHotKeyPressed;
            _hotKeyManager = null;
            _commandParameterCallback = null;
        }

        private void HotKeyManagerOnLocalHotKeyPressed(object sender, LocalHotKeyEventArgs localHotKeyEventArgs)
        {
            Command.Execute(_commandParameterCallback());
        }
    }
}
