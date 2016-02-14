using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Modules.InstanceDetails;
using WinFwk.UIMessages;

namespace MemoScope.Modules.Inspector
{
    public class InspectorModule : InstanceDetailsModule, IMessageListener<SelectedClrDumpObjectMessage>
    {
        public void HandleMessage(SelectedClrDumpObjectMessage message)
        {
            if(message.SelectedInstance.ClrDump.Id != ClrDump.Id)
            {
                return;
            }

            Init(message.SelectedInstance);
            Init();
            PostInit();

            Name = $"#{ClrDump.Id} - Inspector";
            Summary = message.SelectedInstance.Address.ToString("X");
        }

        public void Setup(ClrDump data)
        {
            ClrDump = data;
            Name = $"#{ClrDump.Id} - Inspector";
            Icon = Properties.Resources.microscope_small;
            InitColumns();
        }
    }
}
