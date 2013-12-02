using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.Foundation
{
    public interface IUnitTabPageFactory
    {
        IUnitTabPage CreateTabPage(IUnitEditorView unitEditorView);
    }
}