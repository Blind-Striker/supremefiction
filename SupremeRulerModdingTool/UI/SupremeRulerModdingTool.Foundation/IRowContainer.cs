using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation
{
    public interface IRowContainer
    {
        void Set(string category, IList<DataRow> rows);

        KeyValuePair<string, IList<DataRow>>? Get();
    }
}
