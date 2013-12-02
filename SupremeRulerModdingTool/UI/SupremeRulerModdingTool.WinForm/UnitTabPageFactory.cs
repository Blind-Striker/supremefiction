using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    internal class UnitTabPageFactory : IUnitTabPageFactory
    {
        public IUnitTabPage CreateTabPage(IUnitEditorView unitEditorView)
        {
            var unitTabPage = new UnitTabPage();
            unitTabPage.SetUnitEditor(unitEditorView);

            return unitTabPage;
        }
    }
}
