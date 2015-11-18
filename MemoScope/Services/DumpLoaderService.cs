using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using MemoScope.Modules.Explorer;
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
                    Thread.Sleep(5000);
                    Log("File loaded: " + fileInfo.FullName);
                });
            }
        }
    }
}
