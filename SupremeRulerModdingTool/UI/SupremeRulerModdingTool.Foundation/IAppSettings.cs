using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeRulerModdingTool.Foundation
{
    public interface IAppSettings
    {
        object this[string key] { get; set; }

        void Save();
    }
}
