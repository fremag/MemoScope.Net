using BrightIdeasSoftware;
using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Linq;
using WinFwk.UIModules;

namespace MemoScope.Modules.TypeDetails
{
    public partial class TypeDetailsModule : UIModule
    {
        private ClrType type;
        private ClrDump dump;
        public TypeDetailsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDumpType dumpType)
        {
            type = dumpType.ClrType;
            dump = dumpType.ClrDump;
            pgTypeInfo.SelectedObject = new TypeInformations(dumpType);
            Generator.GenerateColumns(dlvFields, typeof(FieldInformation), false);
            dlvFields.SetObjects( dumpType.Fields.Select(clrField => new FieldInformation(dumpType, clrField) ));
        }

        public override void PostInit()
        {
            Name = "#"+dump.Id+" - "+type.Name;
            Summary = type.Name;
        }
    }
}
