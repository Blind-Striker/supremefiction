using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvpVmFramework.Core.Foundation;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.Foundation.Presenters
{
    public interface IUnitEditorPresenter : IPresenter<IUnitEditorView>
    {
        void InitializeView(string path);
    }
}
