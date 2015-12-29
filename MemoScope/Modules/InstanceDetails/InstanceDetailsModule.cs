using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using WinFwk.UIModules;

namespace MemoScope.Modules.InstanceDetails
{
    public partial class InstanceDetailsModule : UIModule
    {
        private ClrDumpObject ClrDumpObject { get; set; }
        List<FieldValueInformation> mainFieldValues;
        public InstanceDetailsModule()
        {
            InitializeComponent();
        }

        internal void Setup(ClrDumpObject clrDumpObject)
        {
            ClrDumpObject = clrDumpObject;
            tbAddress.Text = clrDumpObject.Address.ToString("X");
            tbType.Text = clrDumpObject.ClrType.Name;

            // Fields
            Generator.GenerateColumns(dtlvFieldsValues, typeof(FieldValueInformation), false);
            dtlvFieldsValues.CanExpandGetter = o => ((FieldValueInformation)o).HasChildren;
            dtlvFieldsValues.ChildrenGetter = o => ((FieldValueInformation)o).GetChildren();

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
            ObjectListViewHelpers.SetUpTypeColumn(dtlvFieldsValues, nameof(FieldValueInformation.TypeName));
            ObjectListViewHelpers.SetUpAddressColumn(dtlvFieldsValues, nameof(FieldValueInformation.Address),
                (o) => ((FieldValueInformation)o).Address,
                (o) => ((FieldValueInformation)o).ClrType,
                ClrDumpObject.ClrDump, this);


            // References
            Generator.GenerateColumns(dtlvReferences, typeof(ReferenceInformation), false);
            dtlvReferences.CanExpandGetter = o => ((ReferenceInformation)o).HasChildren;
            dtlvReferences.ChildrenGetter = o => ((ReferenceInformation)o).Children;
            ObjectListViewHelpers.SetUpTypeColumn(dtlvReferences, nameof(ReferenceInformation.TypeName));
            ObjectListViewHelpers.SetUpAddressColumn(dtlvReferences, nameof(ReferenceInformation.Address),
                (o) => ((ReferenceInformation)o).Address,
                (o) => ((ReferenceInformation)o).ClrType,
                ClrDumpObject.ClrDump, this);

        }

        public override void Init()
        {
            mainFieldValues = FieldValueInformation.GetChildren(ClrDumpObject);
        }

        public override void PostInit()
        {
            dtlvFieldsValues.Roots = mainFieldValues;
            dtlvReferences.Roots = new[] { new ReferenceInformation(ClrDumpObject.ClrDump, ClrDumpObject.Address) };
            Name = "#" + ClrDumpObject.ClrDump.Id + " - " + ClrDumpObject.Address.ToString("X");
            Summary = ClrDumpObject.ClrType.Name;
        }
    }


}
