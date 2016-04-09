using MemoScope.Core;
using System.Collections.Generic;
using System.Threading;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace MemoScope.Modules.RootPath
{
    public static class RootPathAnalysis
    {
        public static List<RootPathInformation> AnalyzeRootPath(MessageBus msgBus, ClrDump clrDump, ulong address)
        {
            CancellationTokenSource token = new CancellationTokenSource();
            msgBus.BeginTask("Analysing Root Path...", token);
            if( token.IsCancellationRequested)
            {
                msgBus.EndTask("Root Path analysis: cancelled.");
                return null;
            }
            msgBus.EndTask("Root Path analysed.");
            return null;
        }
    }
}
