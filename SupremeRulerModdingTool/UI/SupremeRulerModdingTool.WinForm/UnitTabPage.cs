using System.Windows.Forms;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    internal class UnitTabPage : TabPage, IUnitTabPage
    {
        public string TabName
        {
            get { return Text; }
            set { Text = value; }
        }

        public void SetUnitEditor(IUnitEditorView view)
        {
            Controls.Clear();

            if (!(view is Control))
            {
                 // Todo throw exception
            }

            var control = view as Control;

            control.Dock = DockStyle.Fill;

            Controls.Add(control);
        }
    }
}
