using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using WinFwk.UIMessages;
using WinFwk.UITools;

namespace MemoScope.Modules.Referers
{
    public class ReferersInformation : ITreeNodeInformation<ReferersInformation>, ITypeNameData
    {
        [OLVColumn]
        public string TypeName => ClrType.Name;

        [IntColumn(Title="# Instances")]
        public int InstancesCount => Instances.Count;

        [IntColumn(Title = "# References")]
        public int ReferencesCount => References.Count;

        [OLVColumn]
        public string FieldName { get; }

        public HashSet<ulong> Instances { get; }
        public HashSet<ulong> References { get; }

        public ClrType ClrType { get; }
        ClrDump ClrDump { get; }
        MessageBus MessageBus { get; }

        private bool canExpand;

        public ReferersInformation(ClrDump clrDump, ClrType clrType, string fieldName, MessageBus messageBus)
        {
            ClrDump = clrDump;
            ClrType = clrType;
            FieldName = fieldName;
            MessageBus = messageBus;
            Instances = new HashSet<ulong>();
            References = new HashSet<ulong>();
        }

        public ReferersInformation(ClrDump clrDump, ClrType clrType, MessageBus messageBus, IAddressContainer addresses) : this(clrDump, clrType, null, messageBus)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                Instances.Add(addresses[i]);
            }
            Init();
        }

        public void Init()
        {
            canExpand = ReferersAnalysis.HasReferers(MessageBus, ClrDump, Instances);
        }

        bool ITreeNodeInformation<ReferersInformation>.CanExpand => canExpand;

        List<ReferersInformation> ITreeNodeInformation<ReferersInformation>.Children
        {
            get
            {
                return ReferersAnalysis.AnalyzeReferers(MessageBus, ClrDump, Instances);
            }
        }
    }
}
