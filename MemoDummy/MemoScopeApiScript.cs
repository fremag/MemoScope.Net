using System.ComponentModel;
using System.Diagnostics;
using MemoScopeApi;

namespace MemoDummy
{
    public class MemoScopeApiScript : AbstractMemoScript
    {
        public override string Name => "MemoScope Api Test";
        public override string Description => "Ask MemoScope to dump MemoDumy";

        [ReadOnly(true)]
        public int ProcessId => Process.GetCurrentProcess().Id;

        public override void Run()
        {
            var client = new MemoScopeClient();
            client.Open();
            client.DumpMe();
        }
    }
}