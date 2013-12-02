using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvpVmFramework.Core.Foundation;
using SupremeRulerModdingTool.Foundation.Presenters;

namespace SupremeRulerModdingTool.Foundation.Views
{
    public interface ISelectGamePathView : IPresenteredView<ISelectGamePathPresenter>
    {
        void ShowDialog(object owner);

        void Close();
    }
}
