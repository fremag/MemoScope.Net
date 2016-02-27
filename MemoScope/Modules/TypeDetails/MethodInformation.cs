using BrightIdeasSoftware;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.TypeDetails
{
    internal class MethodInformation : ITypeNameData
    {
        private ClrMethod clrMethod;
        private ClrDumpType dumpType;

        public MethodInformation(ClrDumpType dumpType, ClrMethod clrMethod)
        {
            this.dumpType = dumpType;
            this.clrMethod = clrMethod;
        }

        [OLVColumn(Title = "Name", Width = 150)]
        public string Name => clrMethod.Name;
        [OLVColumn(Title = "Type")]
        public string TypeName => clrMethod.Type.Name;
        [OLVColumn(Title = "CompilationType", Width = 150)]
        public MethodCompilationType CompilationType => clrMethod.CompilationType;
        [OLVColumn(Title = "Signature", Width = 450)]
        public string Signature => clrMethod.GetFullSignature();
        [OLVColumn(Title = "IsAbstract", Width = 100)]
        public bool IsAbstract => clrMethod.IsAbstract;
        [OLVColumn(Title = "IsClassConstructor", Width = 100)]
        public bool IsClassConstructor => clrMethod.IsClassConstructor;
        [OLVColumn(Title = "IsConstructor", Width = 100)]
        public bool IsConstructor => clrMethod.IsConstructor;
        [OLVColumn(Title = "IsFinal", Width = 100)]
        public bool IsFinal => clrMethod.IsFinal;
        [OLVColumn(Title = "IsInternal", Width = 100)]
        public bool IsInternal => clrMethod.IsInternal;
        [OLVColumn(Title = "IsPInvoke", Width = 100)]
        public bool IsPInvoke => clrMethod.IsPInvoke;
        [OLVColumn(Title = "IsPrivate", Width = 100)]
        public bool IsPrivate => clrMethod.IsPrivate;
        [OLVColumn(Title = "IsProtected", Width = 100)]
        public bool IsProtected => clrMethod.IsProtected;
        [OLVColumn(Title = "IsPublic", Width = 100)]
        public bool IsPublic => clrMethod.IsPublic;
        [OLVColumn(Title = "IsStatic", Width = 100)]
        public bool IsStatic => clrMethod.IsStatic;
        [OLVColumn(Title = "IsVirtual", Width = 100)]
        public bool IsVirtual => clrMethod.IsVirtual;

        public ClrType ClrType=> clrMethod.Type;
    }
}