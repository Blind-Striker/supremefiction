using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using System.Windows.Input;
using SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandBindings;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.CommandAdapters.CommandFactories
{
    public class KeyPressCommandBindingFactory : CommandBindingFactory
    {
        protected override bool CanCreateCore(Component component)
        {
            return component is ContainerControl;
        }

        protected override CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            var containerControl = component as ContainerControl;

            if (containerControl == null)
            {
                throw new ArgumentException("This factory cannot create a CommandBindingBase for the passed component.");
            }

            return new KeyPressCommandBinding(containerControl, command, commandParameterCallback);
        }
    }
}
