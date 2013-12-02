using System.ComponentModel;
using System.Windows.Forms;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    internal class UnitTabPage : TabPage, IUnitTabPage
    {
        private Container _components;

        public UnitTabPage(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public string TabName
        {
            get { return Text; }
            set { Text = value; }
        }

        public ContextMenu Menu { get; set; }

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new Container();
        }
    }
}
