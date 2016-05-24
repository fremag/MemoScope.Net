using System.Collections.Generic;
using MemoScope.Core;
using System.Linq;
using MemoScope.Core.Data;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using System.Threading;
using System;

namespace MemoScope.Modules.Arrays
{
    public class ArraysAnalysis
    {
        internal static List<ArraysInformation> Analyse(ClrDump clrDump, MessageBus msgBus)
        {
            CancellationTokenSource token = new CancellationTokenSource();
            var arrays = new List<ArraysInformation>();
            msgBus.BeginTask("Analyzing arrays...", token);
            int n = 0;
            clrDump.Run(() =>
            {
                var arrayTypes = clrDump.AllTypes.Where(t => t.IsArray);
                int nbArrayType = arrayTypes.Count();
                foreach (var type in arrayTypes)
                {
                    string typeName = type.Name;
                    msgBus.Status($"Analyzing array type: {typeName} ({n:###,###,###,##0}/{nbArrayType:###,###,###,##0})");
                    if ( token.IsCancellationRequested )
                    {
                        return;
                    }
                    n++;
                    ulong nbInstances = 0;
                    ulong totalSize = 0;
                    ulong totalLength = 0;
                    ulong maxLength = 0;
                    foreach (var address in clrDump.EnumerateInstances(type))
                    {
                        nbInstances++;
                        var length = (ulong)(type.GetArrayLength(address));
                        maxLength = Math.Max(maxLength, length);
                        totalSize += type.GetSize(address);
                        totalLength += length;
                        if (nbInstances % 512 == 0)
                        {
                            msgBus.Status($"Analyzing array: #{nbInstances:###,###,###,##0} for type: {typeName}");
                            if (token.IsCancellationRequested)
                            {
                                return;
                            }
                        }
                    }
                    arrays.Add(new ArraysInformation(new ClrDumpType(clrDump, type), nbInstances, totalLength, maxLength, totalSize));
                }
            });
            msgBus.EndTask($"Arrays analyzed. Types: {n:###,###,###,##0}");
            return arrays;
        }
    }
}
