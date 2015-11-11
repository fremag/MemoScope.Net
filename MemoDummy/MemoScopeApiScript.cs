using System.Diagnostics;
using MemoScopeApi;

namespace MemoDummy
{
    public class MemoScopeApiScript : AbstractMemoScript
    {
        public override string Name => "MemoScope Api Test";
        public override string Description => "Ask MemoScope to dump MemoDumy";

        public override void Run()
        {
            var client = new MemoScopeClient(Process.GetCurrentProcess().Id);
            client.Open();
            client.DumpMe();
        }
    }
}