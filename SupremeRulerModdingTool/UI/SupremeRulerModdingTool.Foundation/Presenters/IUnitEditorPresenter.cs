﻿using System;
using MvpVmFramework.Core.Foundation;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Views;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Presenters
{
    public interface IUnitEditorPresenter : IPresenter<IUnitEditorView>, IDisposable
    {
        IUnitTabPage UnitTabPage { get; set; }

        bool IsDirty { get; }
        string Name { get; set; }

        void PrepForUpdate(string path);

        void Save();
        void InitializeNewView(string name);
        void DeleteRows();
        void CopyRows();
        void PasteRows();
    }
}
