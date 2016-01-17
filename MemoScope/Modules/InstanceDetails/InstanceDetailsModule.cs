using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using System.Collections.Generic;

namespace MemoScope.Modules.InstanceDetails
{
    public partial class InstanceDetailsModule : UIClrDumpModule
    {
        private ClrDumpObject ClrDumpObject { get; set; }
        private List<FieldValueInformation> mainFieldValues;

        public InstanceDetailsModule()
        {
            InitializeComponent();
        }

        internal void Setup(ClrDumpObject clrDumpObject)
        {
            ClrDumpObject = clrDumpObject;
            ClrDump = clrDumpObject.ClrDump;
            tbAddress.Text = clrDumpObject.Address.ToString("X");
            tbType.Text = clrDumpObject.ClrType?.Name;

            // Fields
            dtlvFieldsValues.InitData<FieldValueInformation>();
            dtlvFieldsValues.SetUpTypeColumn(nameof(FieldValueInformation.TypeName), this);
            dtlvFieldsValues.SetUpAddressColumn<FieldValueInformation>(this);

            // References
            dtlvReferences.InitData<ReferenceInformation>();
            dtlvReferences.SetUpTypeColumn(nameof(ReferenceInformation.TypeName), this);
            dtlvReferences.SetUpAddressColumn<ReferenceInformation>(this);
        }

        public override void Init( )
        {
            mainFieldValues = FieldValueInformation.GetChildren(ClrDumpObject);
        }

        public override void PostInit()
        {
            dtlvFieldsValues.Roots = mainFieldValues;
            dtlvReferences.Roots = new[] { new ReferenceInformation(ClrDumpObject.ClrDump, ClrDumpObject.Address) };

            Name = "#" + ClrDumpObject.ClrDump.Id + " - " + ClrDumpObject.Address.ToString("X");
            Summary = ClrDumpObject.ClrType == null ? "Unkown" : ClrDumpObject.ClrType.Name;
            Icon = Properties.Resources.elements_small;
        }
    }


}
