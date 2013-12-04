using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    public class WinFormPromptDialog : IPromptDialog
    {
        public string ShowDialog(string text, string caption)
        {
            var prompt = new Form { Width = 500, Height = 150, Text = caption };
            var textLabel = new Label { Left = 50, Top = 20, Text = text };
            var textBox = new TextBox { Left = 50, Top = 50, Width = 400 };
            var confirmation = new Button { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => prompt.Close();

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();

            return textBox.Text;
        }
    }
}
