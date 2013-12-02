using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;

namespace SupremeRulerModdingTool.Core
{
    public class BaseForm : Form
    {
        private readonly CommandAdapter _commandAdapter;

        public BaseForm()
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
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.ResumeLayout(false);
        }
    }
}
