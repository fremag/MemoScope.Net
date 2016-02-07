using MemoScope.Core;
using MemoScope.Modules.StackTrace;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using MemoScope.Core.Helpers;

namespace MemoScope.Modules.ThreadException
{
    public partial class ThreadExceptionModule : UIClrDumpModule
    {
        public List<ClrExceptionInformation> Exceptions { get; private set; }
        private ClrThread ClrThread { get; set; }
        private string Message { get; set; }
        private List<StackFrameInformation> StackFrames { get; set; }

        public ThreadExceptionModule()
        {
            InitializeComponent();
            dlvStackTrace.InitColumns<StackFrameInformation>();
            dlvExceptions.InitColumns<ClrExceptionInformation>();
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
            Summary = $"Id: {ClrThread.ManagedThreadId} : {Exceptions.Count} exceptions";
        }

        public override void Init()
        {
            Exceptions = new List<ClrExceptionInformation>();
            ClrException exception =  ClrDump.Eval(() => ClrThread.CurrentException);
            while(exception != null)
            {
                Exceptions.Add(new ClrExceptionInformation(ClrDump, exception));
                exception = ClrDump.Eval(() => exception.Inner);
            }

            dlvExceptions.Objects = Exceptions;
        }

        private void dlvExceptions_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var exception = dlvExceptions.SelectedObject<ClrExceptionInformation>();
            if( exception != null)
            {
                Init(exception);
            }
        }

        private void Init(ClrExceptionInformation exception)
        {
            tbExceptionType.Text = exception.TypeName;
            tbMessage.Text = exception.Message;
            dlvStackTrace.Objects = exception.StackFrames;
        }
    }
}
