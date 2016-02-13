using System.Collections.Generic;
using MemoScope.Modules.Arrays;
using WinFwk.UIMessages;
using System.Threading;
using WinFwk.UIModules;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.ArrayInstances
{
    public class ArrayInstanceAnalysis
    {
        public static List<ArrayInstanceInformation> Analyze(ArraysAddressList arrayAddressList, MessageBus msgBus)
        {
            var clrDump = arrayAddressList.ClrDump;
            var clrType = arrayAddressList.ClrType;
            var typeName = clrType.Name;
            CancellationTokenSource token = new CancellationTokenSource();
            msgBus.BeginTask($"Analyzing arrays: {typeName}...", token);

            List<ArrayInstanceInformation> result = clrDump.Eval(() =>
            {
                var tmp = new List<ArrayInstanceInformation>();
                var count = arrayAddressList.Addresses.Count;
                for (int i=0; i < count; i++) {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    var address = arrayAddressList.Addresses[i];
                    int length = clrType.GetArrayLength(address);
                    if (i % 128 == 0)
                    {
                        msgBus.Status($"Analyzing instance: {i} / {count}");
                    }
                    float nullRatio = 0;
                    if ( clrType.ElementType == ClrElementType.Object || clrType.ElementType == ClrElementType.String || clrType.ElementType == ClrElementType.SZArray)
                    {
                        int nbNull = 0;
                        for(int j=0; j < length; j++)
                        {
                            object elemAddress = clrType.GetArrayElementValue(address, j);
                            if( elemAddress is ulong && (ulong)elemAddress == 0)
                            {
                                nbNull++;
                            }
                            else if (elemAddress == null)
                            {
                                nbNull++;
                            }
                            if (j % 256 == 0)
                            {
                                msgBus.Status($"Analyzing instance: {i} / {count}, element {j} / {length}");
                            }
                        }
                        nullRatio = ((float)nbNull) / length;
                    }

                    ArrayInstanceInformation info = new ArrayInstanceInformation(clrDump, clrType, address, length, nullRatio);
                    tmp.Add(info);
                }
                return tmp;
            });
            msgBus.EndTask("Arrays analyzed.");
            return result;
        }
    }
}
