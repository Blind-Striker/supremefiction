using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation
{
    public interface IUnitTabPage
    {
        string TabName { get; set; }

        void SetUnitEditor(IUnitEditorView view);
    }
}
