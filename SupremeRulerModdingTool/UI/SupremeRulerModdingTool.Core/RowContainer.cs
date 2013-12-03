using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Core
{
    public class RowContainer : IRowContainer
    {
        private KeyValuePair<string, IList<DataRow>>? _rowsKeyValuePair;

        public void Set(string category, IList<DataRow> rows)
        {
            _rowsKeyValuePair = new KeyValuePair<string, IList<DataRow>>(category, rows);
        }

        public KeyValuePair<string, IList<DataRow>>? Get()
        {
            return _rowsKeyValuePair;
        }
    }
}
