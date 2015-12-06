using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

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
        private static Dictionary<string, string> aliasCache = new Dictionary<string, string>();

        public static string ManageAlias(string typeName, List<TypeAlias> typeAliases)
        {
            string alias;
            if (aliasCache.TryGetValue(typeName, out alias))
            {
                return alias;
            }
            if (typeName.IndexOf('<') < 0)
            {
                return CheckAlias(typeName, typeAliases);
            }

            string res = "";
            string buf = "";
            for (int i = 0; i < typeName.Length; i++)
            {
                char c = typeName[i];
                switch (c)
                {
                    case ' ':
                        break;
                    case '<':
                    case '>':
                    case ',':
                        if (!string.IsNullOrEmpty(buf))
                        {
                            string newBuf = CheckAlias(buf, typeAliases);
                            res += newBuf;
                        }
                        res += c;
                        buf = "";
                        break;
                    default:
                        buf += c;
                        break;
                }
            }
            return res;
        }

        private static string CheckAlias(string buf, List<TypeAlias> typeAliases)
        {
            foreach (var typeAlias in typeAliases.Where(ta => ta.Active))
            {
                if (buf.Contains(typeAlias.OldTypeName))
                {
                    buf = buf.Replace(typeAlias.OldTypeName, typeAlias.NewTypeName);
                }
            }
            return buf;
        }
    }
}