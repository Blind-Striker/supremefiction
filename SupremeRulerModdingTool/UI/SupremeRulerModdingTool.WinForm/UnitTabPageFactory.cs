using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremeRulerModdingTool.Foundation;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.WinForm
{
    internal class UnitTabPageFactory : IUnitTabPageFactory
    {
        public IUnitTabPage CreateTabPage(IUnitEditorView unitEditorView)
        {
            UnitTabPage unitTabPage = new UnitTabPage();
            unitTabPage.SetUnitEditor(unitEditorView);

            return unitTabPage;
        }
    }
}
