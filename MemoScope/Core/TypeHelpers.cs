using Microsoft.Diagnostics.Runtime;
using System.Text.RegularExpressions;

namespace MemoScope.Core
{
    static public class TypeHelpers
    {
        private static readonly Regex fieldNameRegex = new Regex("^<(.*)>k__BackingField$", RegexOptions.Compiled);
        public static string RealName(this ClrInstanceField field)
        {
            var match = fieldNameRegex.Match(field.Name);

            if (match.Success)
                return match.Groups[1].Value+" [*]";

            return field.Name;
        }
    }
}
