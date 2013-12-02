using System;
using System.ComponentModel;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using System.Windows.Input;
using SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandFactories
{
    public class TabControlCommandBindingFactory : CommandBindingFactory
    {
        protected override bool CanCreateCore(Component component)
        {
            return component is ExitableTabControl && ((ExitableTabControl)component).Identity == "TabControl";
        }

        protected override CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            var tabControl = component as TabControl;

            if (tabControl == null)
            {
                throw new ArgumentException("This factory cannot create a CommandBindingBase for the passed component.");
            }

            return new TabControlBinding(tabControl, command, commandParameterCallback);
        }
    }
}
