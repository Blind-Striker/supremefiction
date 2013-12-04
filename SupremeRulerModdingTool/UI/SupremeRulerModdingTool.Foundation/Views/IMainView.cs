using System.Collections.Generic;
using MvpVmFramework.Core.Foundation;

using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views
{
    public interface IMainView : IPresenteredView<IMainPresenter>
    {
        IEnumerable<IUnitTabPage> UnitTabPages { get; }

        void RemoveTab(IUnitTabPage unitTabPage);

        void AddTab(IUnitTabPage unitTabPage);

        void RemoveAllTabs();
    }
}
