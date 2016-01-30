using MemoScope.Core;
using System.Collections.Generic;
using MemoScope.Modules.Threads;
using System.Linq;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.StackTrace
{
    public partial class StackTraceModule : UIClrDumpModule
    {
        private List<StackFrameInformation> StackFrames;

        public ClrThread Thread { get; private set; }

        public StackTraceModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump, ClrThread thread)
        {
            ClrDump = clrDump;
            Thread = thread;
            Icon = Properties.Resources.red_line_small;
            Name = $"#{clrDump.Id} - StackTrace - Id: {Thread?.ManagedThreadId}";

            dlvStackFrames.InitColumns<StackFrameInformation>();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"Id: {Thread?.ManagedThreadId}";
            ThreadProperty props;
            if (Thread != null && ClrDump.ThreadProperties.TryGetValue(Thread.ManagedThreadId, out props) )
            {
                Summary = $"Name: {props.Name}, " + Summary;
            }

            dlvStackFrames.Objects = StackFrames;
        }

        public override void Init()
        {
            StackFrames = ClrDump.Eval(() =>  Thread.StackTrace.Select( frame => new StackFrameInformation(ClrDump, frame) )).ToList();
        }
    }
}
