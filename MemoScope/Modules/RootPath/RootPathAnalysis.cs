using MemoScope.Core;
using MemoScope.Core.Data;
using System.Collections.Generic;
using System.Threading;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace MemoScope.Modules.RootPath
{
    public static class RootPathAnalysis
    {
        public static List<RootPathInformation> AnalyzeRootPath(MessageBus msgBus, ClrDumpObject clrDumpObject)
        {
            ClrDump clrDump = clrDumpObject.ClrDump;
            ulong address = clrDumpObject.Address;
            CancellationTokenSource token = new CancellationTokenSource();
            msgBus.BeginTask("Analysing Root Path...", token);
            if( token.IsCancellationRequested)
            {
                msgBus.EndTask("Root Path analysis: cancelled.");
                return null;
            }

            List<RootPathInformation> path = new List<RootPathInformation>();
            foreach( var refAddress in clrDump.EnumerateReferers(address))
            {
                var refClrDumpObject = new ClrDumpObject(clrDump, clrDump.GetObjectType(refAddress), refAddress);
                var fieldName = clrDump.GetFieldNameReference(refAddress, address);
                path.Add(new RootPathInformation(refClrDumpObject, fieldName));
            }
            msgBus.EndTask("Root Path analysed.");
            return path;
        }
    }
}
