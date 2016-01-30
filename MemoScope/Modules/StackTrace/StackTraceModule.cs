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

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.red_line_small;
            Name = $"#{clrDump.Id} - StackTrace";

            dlvStackFrames.InitColumns<StackFrameInformation>();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"Id: {Thread.ManagedThreadId}";
            ThreadProperty props;
            if (ClrDump.ThreadProperties.TryGetValue(Thread.ManagedThreadId, out props) )
            {
                Summary = $"Name: {props.Name}, " + Summary;
            }

            dlvStackFrames.Objects = StackFrames;
        }
        public void Init(ThreadInformation thread)
        {
            Init(thread.Thread);
        }

        public void Init(ClrThread thread)
        {
            Thread = thread;
            StackFrames = ClrDump.Eval(() =>  thread.StackTrace.Select( frame => new StackFrameInformation(ClrDump, frame) )).ToList();
        }
    }
}
