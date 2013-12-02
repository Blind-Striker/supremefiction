using System.Collections.Generic;
using System.Linq;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Models;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation
{
    public static class StringExtensions
    {
        public static IEnumerable<ComboboxItem> ToComboboxItems(this IEnumerable<string> strings)
        {
            return strings.Select(s => new ComboboxItem { ComboboxItemDisplayMember = s, ComboboxItemValueMember = s });
        }
    }
}
