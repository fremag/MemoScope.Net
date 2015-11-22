using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using MemoScope.Core;
using MemoScope.Modules.Explorer;
using Microsoft.Diagnostics.Runtime;
using WinFwk.UIMessages;
using WinFwk.UIServices;

namespace MemoScope.Services
{
    public class DumpLoaderService : AbstractUIService, IMessageListener<OpenDumpRequest>
    {
        private readonly TaskFactory fact;

        public DumpLoaderService()
        {
            var sched = new LimitedConcurrencyLevelTaskScheduler(1);
            fact = new TaskFactory(sched);
        }

        public void HandleMessage(OpenDumpRequest openDumpRequest)
        {
            foreach (var fileInfo in openDumpRequest.FileInfos)
            {
                fact.StartNew(() =>
                {
                    Log("Loading file: " + fileInfo.FullName);
                    DataTarget target = DataTarget.LoadCrashDump(fileInfo.FullName);
                    try
                    {
                        if( Environment.Is64BitProcess && target.PointerSize != 8 )
                        { 
                            throw new InvalidOperationException($"Wrong architecture ! Dumpfile : {target.PointerSize*8} bits, Environment.Is64BitProcess : {Environment.Is64BitProcess}");
                        }

                        var clrDump = new ClrDump(target, fileInfo.FullName, MessageBus);
                        Log("File loaded: " + fileInfo.FullName);
                        MessageBus.SendMessage(new ClrDumpLoadedMessage(clrDump));
                    }
                    catch
                    {
                        target.Dispose();
                        throw;
                    }
                });
            }
        }
    }
}