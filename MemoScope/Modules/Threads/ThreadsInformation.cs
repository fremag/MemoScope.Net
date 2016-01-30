using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using BrightIdeasSoftware;
using System.Windows.Forms;
using MemoScope.Core.Data;

namespace MemoScope.Modules.Threads
{
    public class ThreadInformation : IAddressData
    {
        public ClrDump ClrDump { get; }
        public ClrThread Thread { get; }

        public ThreadInformation(ClrDump clrDump, ClrThread thread)
        {
            ClrDump = clrDump;
            Thread = thread;

            clrDump.Run(() =>
           {
               OSThreadId = thread.OSThreadId;
               ManagedThreadId = thread.ManagedThreadId;
               CurrentException = thread.CurrentException?.Type?.Name;
               GcMode = thread.GcMode;
               IsAborted = thread.IsAborted;
               IsAbortRequested = thread.IsAbortRequested;
               IsAlive = thread.IsAlive;

               IsBackground = thread.IsBackground;
               IsCoInitialized = thread.IsCoInitialized;
               IsDebuggerHelper = thread.IsDebuggerHelper;
               IsDebugSuspended = thread.IsDebugSuspended;
               IsFinalizer = thread.IsFinalizer;
               IsGC = thread.IsGC;
               IsGCSuspendPending = thread.IsGCSuspendPending;
               IsMTA = thread.IsMTA;
               IsShutdownHelper = thread.IsShutdownHelper;
               IsSTA = thread.IsSTA;
               IsSuspendingEE = thread.IsSuspendingEE;
               IsThreadpoolCompletionPort = thread.IsThreadpoolCompletionPort;
               IsThreadpoolGate = thread.IsThreadpoolGate;
               IsThreadpoolTimer = thread.IsThreadpoolTimer;
               IsThreadpoolWait = thread.IsThreadpoolWait;
               IsThreadpoolWorker = thread.IsThreadpoolWorker;
               IsUnstarted = thread.IsUnstarted;
               IsUserSuspended = thread.IsUserSuspended;
               LockCount = thread.LockCount;
           });
        }

        [OLVColumn]
        public ulong Address { get; set; }

        [OLVColumn(Title = "OS Id", TextAlign = HorizontalAlignment.Right, Width=50)]
        public uint OSThreadId { get;  private set;}
        [OLVColumn(Title="Thread Id", TextAlign = HorizontalAlignment.Right, Width = 50)]
        public int ManagedThreadId { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width=50, IsEditable =false)]
        public bool IsAlive { get; private set; }
        [OLVColumn]
        public string Name { get; internal set; }
        [OLVColumn(TextAlign = HorizontalAlignment.Right, Width = 50)]
        public int Priority { get; internal set; }
        [OLVColumn(TextAlign = HorizontalAlignment.Right, Width = 50)]
        public uint LockCount { get; private set; }
        [OLVColumn]
        public string CurrentException { get;  private set;}

        [OLVColumn]
        public GcMode GcMode { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsAborted { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsAbortRequested { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsBackground { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsCoInitialized { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsDebuggerHelper { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsDebugSuspended { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsFinalizer { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsGC { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsGCSuspendPending { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsMTA { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsShutdownHelper { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsSTA { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsSuspendingEE { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsThreadpoolCompletionPort { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsThreadpoolGate { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsThreadpoolTimer { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsThreadpoolWait { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsThreadpoolWorker { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsUnstarted { get;  private set;}
        [OLVColumn(TextAlign = HorizontalAlignment.Center, Width = 50, IsEditable = false)]
        public bool IsUserSuspended { get;  private set;}
    }
}