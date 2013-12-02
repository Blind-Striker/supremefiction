using MvpVmFramework.Core.Foundation;

using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views
{
    public interface ISelectGamePathView : IPresenteredView<ISelectGamePathPresenter>
    {
        void ShowDialog(object owner);

        void Close();
    }
}
