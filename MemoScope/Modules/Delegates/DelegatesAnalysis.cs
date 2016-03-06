using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using MemoScope.Core.Data;

namespace MemoScope.Modules.Delegates
{
    public static class DelegatesAnalysis
    {
        public static List<ClrType> GetDelegateTypes(ClrDump clrDump)
        {
            List<ClrType> delegates = new List<ClrType>();
            var maintype = clrDump.GetClrType(typeof(System.MulticastDelegate).FullName);

            foreach(var type in  clrDump.AllTypes)
            {
                if( type.BaseType != null && type.BaseType == maintype && clrDump.CountInstances(type) > 0)
                {
                    delegates.Add(type);
                }
            }

            return delegates;
        }

        public static long CountTargets(ClrDump clrDump, ClrType clrType)
        {
            long count = 0;
            var targetField = clrType.GetFieldByName("_target");
            var invocCountField = clrType.GetFieldByName("_invocationCount");

            foreach (ulong address in clrDump.EnumerateInstances(clrType))
            {
                ClrObject clrObject = new ClrObject(address, clrType);
                ClrObject target = clrObject[targetField];
                if( target.Address != address)
                {
                    count += 1;
                }
                else
                {
                    var invocCount = clrObject[invocCountField];
                    var value = invocCount.SimpleValue;
                    count += (long)value;
                }
            }
            return count;
        }
    }
}
