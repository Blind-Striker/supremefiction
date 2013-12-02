using System;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters
{
    public interface IUnitEditorPresenter : IPresenter<IUnitEditorView>, IDisposable
    {
        IUnitTabPage UnitTabPage { get; set; }

        string UnitPath { get; set; }

        string Name { get; set; }
        bool IsDirty { get; }

        void InitializeView(string path);

        void Save();
    }
}
