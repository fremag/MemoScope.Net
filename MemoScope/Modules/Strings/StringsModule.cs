using MemoScope.Core;
using MemoScope.Core.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFwk.UICommands;
using MemoScope.Core.Helpers;
using BrightIdeasSoftware;
using MemoScope.Modules.Instances;

namespace MemoScope.Modules.Strings
{
    public partial class StringsModule : UIClrDumpModule, UIDataProvider<AddressList>
    {
        private List<StringInformation> Strings { get; set; }

        public StringsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.text_rotate_small;
            Name = $"#{clrDump.Id:###,###,###,##0} - Strings";

            dlvStrings.InitColumns<StringInformation>();
            dlvStrings.RegisterDataProvider(() => Data, this);
        }

        public override void Init()
        {
            base.Init();
            Strings = StringAnalysis.Analyse(ClrDump, MessageBus);
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{Strings.Count:###,###,###,##0} Strings";
            dlvStrings.Objects = Strings;
            dlvStrings.Sort(nameof(StringInformation.Count), SortOrder.Descending);
        }

        public AddressList Data
        {
            get
            {
                var stringType = ClrDump.GetClrType(typeof(string).FullName);
                var stringInfo = dlvStrings.SelectedObject<StringInformation>();
                if(stringInfo ==null)
                {
                    return null;
                }
                return new AddressList(ClrDump, stringType, stringInfo.Addresses);
            }
        }

        private void OnCellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount == 2 && e.Model != null)
            {
                var addresses = Data;
                InstancesModule.Create(addresses, this, mod => RequestDockModule(mod));
            }
        }
    }
}
