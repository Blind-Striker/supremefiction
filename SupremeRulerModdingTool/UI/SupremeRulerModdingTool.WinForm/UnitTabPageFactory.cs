using System.ComponentModel;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    internal class UnitTabPageFactory : IUnitTabPageFactory
    {
        public IUnitTabPage CreateTabPage(IUnitEditorView unitEditorView, IContainer container)
        {
            var unitTabPage = new UnitTabPage(container);
            unitTabPage.SetUnitEditor(unitEditorView);

            return unitTabPage;
        }
    }
}
