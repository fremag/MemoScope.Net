using Microsoft.Diagnostics.Runtime;
using System.Text.RegularExpressions;

namespace MemoScope.Core
{
    static public class TypeHelpers
    {
        private static readonly Regex fieldNameRegex = new Regex("^<(.*)>k__BackingField$", RegexOptions.Compiled);

        public static string RealName(this ClrInstanceField field)
        {
            return RealName(field.Name);
        }

        public static string RealName(string fieldName)
        {
            var match = fieldNameRegex.Match(fieldName);

            if (match.Success)
                return match.Groups[1].Value + " [*]";

            return fieldName;
        }

        ///Regex.Match(s, @"\[\[(.*?)\]\]", RegexOptions.RightToLeft)
    }
}
