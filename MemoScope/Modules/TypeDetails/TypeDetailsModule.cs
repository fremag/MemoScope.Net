using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using MemoScope.Core.Data;

namespace MemoScope.Modules.TypeDetails
{
    public partial class TypeDetailsModule : UIClrDumpModule
    {
        private ClrType type;
        public TypeDetailsModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.blueprint;
        }

        public void Setup(ClrDumpType dumpType)
        {
            type = dumpType.ClrType;
            ClrDump = dumpType.ClrDump;
            pgTypeInfo.SelectedObject = new TypeInformations(dumpType);

            dlvFields.InitColumns<FieldInformation>();
            dlvFields.SetUpTypeColumn<FieldInformation>(this);
            dlvFields.SetObjects(dumpType.Fields.Select(clrField => new FieldInformation(dumpType, clrField)));

            dlvMethods.InitColumns<MethodInformation>();
            dlvMethods.SetUpTypeColumn<MethodInformation>(this);
            dlvMethods.SetObjects(dumpType.Methods.Select(clrMethod => new MethodInformation(dumpType, clrMethod)));

            dtlvParentClasses.InitData<AbstractTypeInformation>();
            dtlvParentClasses.SetUpTypeColumn<AbstractTypeInformation>(this);

            var l = new List<object>();
            var typeInformation = new TypeInformation(dumpType.BaseType);
            var interfaceInformations = InterfaceInformation.GetInterfaces(dumpType);
            l.Add(typeInformation);
            l.AddRange(interfaceInformations);
            dtlvParentClasses.Roots = l;
        }

        public override void PostInit()
        {
            Name = $"#{ClrDump.Id} - {type.Name}";
            Summary = type.Name;
        }

        public override IEnumerable<ObjectListView> ListViews => new ObjectListView[] { dlvFields, dlvMethods, dtlvParentClasses, };
    }
}
