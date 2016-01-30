using MemoScope.Core;
using MemoScope.Modules.StackTrace;
using Microsoft.Diagnostics.Runtime;
using System.Linq;
using System.Collections.Generic;

namespace MemoScope.Modules.ThreadException
{
    public partial class ThreadExceptionModule : UIClrDumpModule
    {
        public ClrException Exception { get; private set; }
        private ClrThread ClrThread { get; set; }
        private string Message { get; set; }
        private List<StackFrameInformation> StackFrames { get; set; }

        public ThreadExceptionModule()
        {
            InitializeComponent();
            dlvStackTrace.InitColumns<StackFrameInformation>();
        }

        public void Setup(ClrDump clrDump, ClrThread clrThread)
        {
            ClrDump = clrDump;
            ClrThread = clrThread;
            Icon = Properties.Resources.exclamation_small;
            Name = $"#{clrDump.Id} - Exception";
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"Id: {ClrThread.ManagedThreadId} : {Message}";
            tbExceptionType.Text = Exception.Type.Name;
            tbMessage.Text = Message;
            dlvStackTrace.Objects = StackFrames;
        }

        public override void Init()
        {
            Exception = ClrDump.Eval(() => ClrThread.CurrentException);
            Message = ClrDump.Eval(() => Exception.Message);
            StackFrames = ClrDump.Eval( () => Exception.StackTrace.Select(frame => new StackFrameInformation(ClrDump, frame))).ToList();
        }
    }
}
