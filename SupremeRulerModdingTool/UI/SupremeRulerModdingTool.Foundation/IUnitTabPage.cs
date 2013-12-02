using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremeRulerModdingTool.Foundation.Views;

namespace SupremeRulerModdingTool.Foundation
{
    public interface IUnitTabPage
    {
        void SetUnitEditor(IUnitEditorView view);
        string TabName { get; set; }
    }
}
