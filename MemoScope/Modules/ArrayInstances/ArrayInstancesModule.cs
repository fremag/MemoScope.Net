using MemoScope.Core;
using System.Collections.Generic;
using BrightIdeasSoftware;
using MemoScope.Modules.Arrays;
using MemoScope.Core.Helpers;
using System.Windows.Forms;

namespace MemoScope.Modules.ArrayInstances
{
    public partial class ArrayInstancesModule : UIClrDumpModule
    {
        private ArraysAddressList ArrayAddressList { get; set; }
        private List<ArrayInstanceInformation> ArrayInstances { get; set; }

        public ArrayInstancesModule()
        {
            InitializeComponent();
        }

        public void Setup(ArraysAddressList arrayAddressList)
        {
            ArrayAddressList = arrayAddressList;
            ClrDump = arrayAddressList.ClrDump;
            Icon = Properties.Resources.formatting_equal_to_small;
            Name = $"#{ArrayAddressList.ClrDump.Id} - {ArrayAddressList.ClrType.Name}";

            dlvArrays.InitColumns<ArrayInstanceInformation>();
            dlvArrays.SetUpAddressColumn<ArrayInstanceInformation>(this);
            dlvArrays.CellClick += OnCellClick;
        }

        public override void Init()
        {
            ArrayInstances = ArrayInstanceAnalysis.Analyze(ArrayAddressList, MessageBus);
        }

        private void OnCellClick(object sender, CellClickEventArgs e)
        {
            if( e.ClickCount == 2 && e.Model != null)
            {
                // TODO
            }
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{ArrayInstances.Count} Arrays";
            dlvArrays.Objects = ArrayInstances;
            dlvArrays.Sort(nameof(ArrayInstanceInformation.Length), SortOrder.Descending);
        }
    }
}
