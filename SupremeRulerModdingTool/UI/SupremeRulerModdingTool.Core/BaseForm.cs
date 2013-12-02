using System.Waf.Presentation.WinForms;
using System.Windows.Forms;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Core
{
    public class BaseForm : Form
    {
        private readonly CommandAdapter _commandAdapter;

        protected BaseForm()
        {
            _commandAdapter = new CommandAdapter();
        }


        protected CommandAdapter CommandAdapter
        {
            get
            {
                return _commandAdapter;
            }
        }

        public void ShowDialog(object owner)
        {
            base.ShowDialog(owner as IWin32Window);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // BaseForm
            ClientSize = new System.Drawing.Size(284, 261);
            Name = "BaseForm";
            ResumeLayout(false);
        }
    }
}
