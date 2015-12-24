using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using WinFwk.UIModules;
using MemoScope.Core.Data;

namespace MemoScope.Modules.TypeDetails
{
    public partial class TypeDetailsModule : UIModule
    {
        private ClrType type;
        private ClrDump dump;
        public TypeDetailsModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.blueprint;
        }

        public void Setup(ClrDumpType dumpType)
        {
            type = dumpType.ClrType;
            dump = dumpType.ClrDump;
            pgTypeInfo.SelectedObject = new TypeInformations(dumpType);

            Generator.GenerateColumns(dlvFields, typeof(FieldInformation), false);
            dlvFields.SetUpTypeColumn(nameof(FieldInformation.Type));
            dlvFields.SetObjects(dumpType.Fields.Select(clrField => new FieldInformation(dumpType, clrField)));
            dlvFields.RegisterDataProvider(() => {
                return new ClrDumpType(dump, dlvFields.SelectedObject<FieldInformation>()?.ClrType);
            }, this);

            Generator.GenerateColumns(dlvMethods, typeof(MethodInformation), false);
            dlvMethods.SetUpTypeColumn(nameof(MethodInformation.Type));
            dlvMethods.SetObjects(dumpType.Methods.Select(clrMethod => new MethodInformation(dumpType, clrMethod)));
            dlvMethods.RegisterDataProvider(() => {
                return new ClrDumpType(dump, dlvMethods.SelectedObject<MethodInformation>()?.ClrType);
            }, this);

            Generator.GenerateColumns(dtlvParentClasses, typeof(AbstractTypeInformation), false);
            dtlvParentClasses.SetUpTypeColumn(nameof(AbstractTypeInformation.Name));
            dtlvParentClasses.CanExpandGetter = model => ((AbstractTypeInformation)model).HasChildren;
            dtlvParentClasses.ChildrenGetter = model => ((AbstractTypeInformation)model).Children;
            var l = new List<object>();
            var typeInformation = new TypeInformation(dumpType.BaseType);
            var interfaceInformations = InterfaceInformation.GetInterfaces(dumpType);
            l.Add(typeInformation);
            l.AddRange(interfaceInformations);
            dtlvParentClasses.Roots = l;
        }

        public override void PostInit()
        {
            Name = "#"+dump.Id+" - "+type.Name;
            Summary = type.Name;
        }
    }
}
