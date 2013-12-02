﻿using MvpVmFramework.Core.Foundation;

using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views
{
    public interface IMainView : IPresenteredView<IMainPresenter>
    {
        void AddTab(IUnitTabPage unitTabPage);
    }
}
