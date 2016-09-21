//#define LINE_AND_FILE
using BrightIdeasSoftware;
using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using WinFwk.UITools;

namespace MemoScope.Modules.StackTrace
{
    public class StackFrameInformation
    {
        private ClrDump clrDump;
        private ClrStackFrame frame;
#if LINE_AND_FILE
        private FileAndLineNumber? fileAndLineNumber;
#endif

        public StackFrameInformation(ClrDump clrDump, ClrStackFrame frame)
        {
            this.clrDump = clrDump;
            this.frame = frame;
            DisplayString = frame.DisplayString;
            Kind = frame.Kind;
            Method = frame.Method;
            
#if LINE_AND_FILE
            if (frame.Kind != ClrStackFrameType.Runtime)
            {
                fileAndLineNumber = clrDump.Eval(() => frame.FileAndLineNumber());
            }
#endif
        }

        public StackFrameInformation(ClrDump clrDump, ClrThread thread)
        {
            this.clrDump = clrDump;
        }

        [OLVColumn]
        public string MethodName => Method != null ? Method.Name : "[*] "+DisplayString;

        [OLVColumn]
        public ClrStackFrameType Kind { get; private set; }

        [OLVColumn(Width=450)]
        public string DisplayString { get; }

        [AddressColumn]
        public ulong StackPointer => frame.StackPointer;

#if LINE_AND_FILE
        [OLVColumn]
        public int? Line => fileAndLineNumber?.Line;

        [OLVColumn]
        public string File => fileAndLineNumber?.File;
#endif
        public ClrMethod Method { get; private set; }
    }
}