using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using MemoScope.Core.Data;
using System;

namespace MemoScope.Modules.Delegates
{
    // Thanks to Alois Kraus for his article about delegate internals:
    // http://geekswithblogs.net/akraus1/archive/2012/05/20/149699.aspx
    public static class DelegatesAnalysis
    {
        const string TargetFieldName = "_target";
        const string InvocationCountFieldName = "_invocationCount";
        const string MethodBaseFieldName = "_methodBase";
        const string MethodPtrFieldName = "_methodPtr";
        const string MethodPtrAuxFieldName = "_methodPtrAux";
        const string InvocationListFieldName = "_invocationList";

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

        internal static List<DelegateTargetInformation> GetDelegateTargetInformations(ClrDumpObject clrDumpObject)
        {
            var targetInformations = new List<DelegateTargetInformation>();
            ClrObject clrObject = clrDumpObject.ClrObject;
            ClrObject target = clrObject[TargetFieldName];
            ulong targetAddress = target.Address;

            if (targetAddress != clrObject.Address)
            {
                var targetType = clrDumpObject.ClrDump.GetObjectType(targetAddress);
                var methPtrObj = clrObject[MethodPtrFieldName];
                var methPtrLong = (long)methPtrObj.SimpleValue;
                var methPtr = (ulong)methPtrLong;
                var methInfo = GetDelegateMethod(methPtr, clrDumpObject.ClrDump);
                targetInformations.Add(new DelegateTargetInformation(targetAddress, new ClrDumpType( clrDumpObject.ClrDump, targetType), methInfo));
                return targetInformations;
            } 

            var invocCount = clrObject[InvocationCountFieldName];
            var v = invocCount.SimpleValue;
            var invocCountValue = (long)v;
            var invocList = clrObject[InvocationListFieldName];
            for(int i=0; i < invocCountValue ; i++)
            {
                var targetObject = invocList[i];
                target = targetObject[TargetFieldName];
                targetAddress = target.Address;
                var targetType = clrDumpObject.ClrDump.GetObjectType(targetAddress);
                var methPtrObj = targetObject[MethodPtrFieldName];
                var methPtrLong = (long)methPtrObj.SimpleValue;
                var methPtr = (ulong)methPtrLong;
                var methInfo = GetDelegateMethod(methPtr, clrDumpObject.ClrDump);
                targetInformations.Add(new DelegateTargetInformation(targetAddress, new ClrDumpType(clrDumpObject.ClrDump, targetType), methInfo));
            }

            return targetInformations;
        }

        // Thanks to Lee Culver and Jeff Cyr
        // for the code:
        // https://github.com/Microsoft/clrmd/issues/35
        public static ClrMethod GetDelegateMethod(ulong methodPtr, ClrDump clrDump)
        {
            ulong magicPtr = methodPtr + 5;
            ulong magicValue1 = clrDump.ReadHeapPointer(magicPtr + 1);
            ulong magicValue2 = clrDump.ReadHeapPointer(magicPtr + 2);

            ulong mysticPtr = magicPtr + 8 * (magicValue2 & 0xFF) + 3;
            ulong mysticOffset = 8 * (magicValue1 & 0xFF);

            ulong mysticValue = clrDump.ReadRuntimePointer(mysticPtr);
            ulong methodDescriptorPtr = mysticValue + mysticOffset;

            ClrMethod method = clrDump.GetMethodByHandle(methodDescriptorPtr);
            return method;  
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
