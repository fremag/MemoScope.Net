using BrightIdeasSoftware;
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
            tbType.Text = clrDumpObject.ClrType.Name;

            // Fields
            dtlvFieldsValues.InitData<FieldValueInformation>();

            dtlvFieldsValues.RegisterDataProvider(() =>
            {
                var type = dtlvFieldsValues.SelectedObject<FieldValueInformation>()?.ClrType;
                if (type != null)
                {
                    return new AddressList(ClrDumpObject.ClrDump, type);
                }
                return null;
            }, this);
            dtlvFieldsValues.RegisterDataProvider(() =>
            {
                var type = dtlvFieldsValues.SelectedObject<FieldValueInformation>()?.ClrType;
                if (type != null)
                {
                    return new ClrDumpType(ClrDumpObject.ClrDump, type);
                }
                return null;
            }, this);

            dtlvFieldsValues.SetUpTypeColumn(nameof(FieldValueInformation.TypeName));
            dtlvFieldsValues.SetUpAddressColumn<FieldValueInformation>(nameof(FieldValueInformation.Address), ClrDumpObject.ClrDump, this);

            // References
            dtlvReferences.InitData<ReferenceInformation>();
            dtlvReferences.SetUpTypeColumn(nameof(ReferenceInformation.TypeName));
            dtlvReferences.SetUpAddressColumn<ReferenceInformation>(nameof(ReferenceInformation.Address), ClrDumpObject.ClrDump, this);
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
            Summary = ClrDumpObject.ClrType.Name;
            Icon = Properties.Resources.elements_small;
        }
    }


}
