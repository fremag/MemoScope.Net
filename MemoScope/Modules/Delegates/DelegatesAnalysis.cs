using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using MemoScope.Core.Data;
using System;

namespace MemoScope.Modules.Delegates
{
    public static class DelegatesAnalysis
    {
        const string TargetFieldName = "_target";
        const string InvocationCountFieldName = "_invocationCount";

        public static bool IsDelegateType(ClrDumpType clrDumpType)
        {
            var delegateType = clrDumpType.ClrDump.GetClrType(typeof(MulticastDelegate).FullName);
            return clrDumpType.BaseType != null && clrDumpType.BaseType.ClrType == delegateType;
        }

        public static List<ClrType> GetDelegateTypes(ClrDump clrDump)
        {
            List<ClrType> delegates = new List<ClrType>();
            var delegateType = clrDump.GetClrType(typeof(MulticastDelegate).FullName);

            foreach(var type in  clrDump.AllTypes)
            {
                if( type.BaseType != null && type.BaseType == delegateType && clrDump.CountInstances(type) > 0)
                {
                    delegates.Add(type);
                }
            }

            return delegates;
        }

        public static long CountTargets(ClrDump clrDump, ClrType clrType)
        {
            long count = 0;
            var targetField = clrType.GetFieldByName(TargetFieldName);
            var invocCountField = clrType.GetFieldByName(InvocationCountFieldName);

            foreach (ulong address in clrDump.EnumerateInstances(clrType))
            {
                count += CountTargets(address, clrType, targetField, invocCountField);
            }
            return count;
        }

        internal static List<DelegateInstanceInformation> GetDelegateInstanceInformation(ClrDumpType clrDumpType)
        {
            var clrType = clrDumpType.ClrType;
            var delegateInstanceInformations = new List<DelegateInstanceInformation>();
            var targetField = clrType.GetFieldByName(TargetFieldName);
            var invocCountField = clrType.GetFieldByName(InvocationCountFieldName);

            foreach (var address in clrDumpType.EnumerateInstances())
            {
                var targets = CountTargets(address, clrType, targetField, invocCountField);
                var delegateInstanceInformation = new DelegateInstanceInformation(address, clrDumpType, targets);
                delegateInstanceInformations.Add(delegateInstanceInformation);
            }

            return delegateInstanceInformations;
        }

        internal static List<DelegateTypeInformation> GetDelegateTypeInformations(ClrDump clrDump)
        {
            var types = GetDelegateTypes(clrDump);
            var typeInformations = new List<DelegateTypeInformation>();
            foreach(var type in types)
            {
                var count = clrDump.CountInstances(type);
                var targets = CountTargets(clrDump, type);
                var delegateInformation = new DelegateTypeInformation(clrDump, type, count, targets);
                typeInformations.Add(delegateInformation);
            }

            return typeInformations;
        }

        public static long CountTargets(ulong address, ClrType clrType, ClrInstanceField targetField, ClrInstanceField invocCountField)
        {
            ClrObject clrObject = new ClrObject(address, clrType);
            ClrObject target = clrObject[targetField];
            if (target.Address != address)
            {
                return 1;
            }

            var invocCount = clrObject[invocCountField];
            var value = invocCount.SimpleValue;
            return (long)value;
        }
    }
}
