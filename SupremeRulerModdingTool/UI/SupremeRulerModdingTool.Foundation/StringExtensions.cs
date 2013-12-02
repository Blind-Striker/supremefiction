using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremeRulerModdingTool.Foundation.Models;

namespace System
{
    public static class StringExtensions
    {
        public static IEnumerable<ComboboxItem> ToComboboxItems(this IEnumerable<string> strings)
        {
            return strings.Select(s => new ComboboxItem() {ComboboxItemDisplayMember = s, ComboboxItemValueMember = s});
        }
    }
}
