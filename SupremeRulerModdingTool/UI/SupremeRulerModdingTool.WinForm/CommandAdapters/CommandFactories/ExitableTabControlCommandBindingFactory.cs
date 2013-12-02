using System;
using System.ComponentModel;
using System.Waf.Presentation.WinForms;
using System.Windows.Input;
using SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandFactories
{
    public class ExitableTabControlCommandBindingFactory : CommandBindingFactory
    {
        protected override bool CanCreateCore(Component component)
        {
           return component is ExitableTabControl && ((ExitableTabControl)component).Identity == "ExitableTabControl";
        }

        protected override CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            var exitableTabControl = component as ExitableTabControl;

            if (exitableTabControl == null)
            {
                throw new ArgumentException("This factory cannot create a CommandBindingBase for the passed component.");
            }

            return new ExitableTabControlBinding(exitableTabControl, command, commandParameterCallback);
        }
    }
}
