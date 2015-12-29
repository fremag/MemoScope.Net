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
        public InstanceDetailsModule()
        {
            InitializeComponent();
        }

        internal void Setup(ClrDumpObject clrDumpObject)
        {
            ClrDumpObject = clrDumpObject;
            tbAddress.Text = clrDumpObject.Address.ToString("X");
            tbType.Text = clrDumpObject.ClrType.Name;
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

        }

        public override void Init( )
        {
            List<FieldValueInformation> fieldValues = FieldValueInformation.GetValues(ClrDumpObject);
            dtlvFieldsValues.Roots = fieldValues; 
        }

        public override void PostInit()
        {
            ObjectListViewHelpers.SetUpTypeColumn(dtlvFieldsValues, nameof(FieldValueInformation.TypeName));
            ObjectListViewHelpers.SetUpAddressColumn(dtlvFieldsValues, nameof(FieldValueInformation.Address),
                (o) => ((FieldValueInformation)o).Address,
                (o) => ((FieldValueInformation)o).ClrType,
                ClrDumpObject.ClrDump, this);
            Name = "#" + ClrDumpObject.ClrDump.Id + " - " + ClrDumpObject.Address.ToString("X");
            Summary = ClrDumpObject.ClrType.Name;
        }
    }


}
