using MvpVmFramework.Core.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters
{
    public interface IUnitEditorPresenter : IPresenter<IUnitEditorView>
    {
        void InitializeView(string path);
    }
}
