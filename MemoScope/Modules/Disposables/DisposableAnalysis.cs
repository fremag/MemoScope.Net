using System.Collections.Generic;
using MemoScope.Core;
using System.Linq;

namespace MemoScope.Modules.Disposables
{
    public static class DisposableAnalysis
    {
        internal static List<DisposableTypeInformation> GetDisposableTypeInformations(ClrDump clrDump)
        {
            List<DisposableTypeInformation> result = new List<DisposableTypeInformation>();
            var stats = clrDump.GetTypeStats().ToDictionary(stat => stat.TypeName);

            foreach (var type in clrDump.AllTypes)
            {
                foreach(var interf in type.Interfaces)
                {
                    if( interf.Name == typeof(System.IDisposable).FullName)
                    {
                        ClrTypeStats stat;
                        if (stats.TryGetValue(type.Name, out stat))
                        {
                            result.Add(new DisposableTypeInformation(stat.Type, stat.NbInstances));
                        }
                    }
                }
            }
            return result;
        }
    }
}
