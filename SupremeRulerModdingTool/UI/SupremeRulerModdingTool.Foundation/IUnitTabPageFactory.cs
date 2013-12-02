using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation
{
    public interface IUnitTabPageFactory
    {
        IUnitTabPage CreateTabPage(IUnitEditorView unitEditorView);
    }
}