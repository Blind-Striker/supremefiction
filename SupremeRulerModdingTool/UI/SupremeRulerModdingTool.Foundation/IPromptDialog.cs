using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation
{
    public interface IPromptDialog
    {
        string ShowDialog(string text, string caption);
    }
}
