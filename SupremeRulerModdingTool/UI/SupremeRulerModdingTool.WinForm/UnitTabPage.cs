using System.Windows.Forms;
using SupremeRulerModdingTool.Foundation;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.WinForm
{
    internal class UnitTabPage : TabPage, IUnitTabPage
    {
        public void SetUnitEditor(IUnitEditorView view)
        {
            Controls.Clear();

            if (!(view is Control))
            {
                 // Todo throw exception
            }

            Control control = view as Control;

            control.Dock = DockStyle.Fill;

            Controls.Add(control);
        }

        public string TabName
        {
            get { return Text; }
            set { Text = value; }
        }
    }
}
