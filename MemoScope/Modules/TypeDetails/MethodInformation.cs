using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.TypeDetails
{
    internal class MethodInformation
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
        [OLVColumn(Title = "Type", Width = 150)]
        public string Type => clrMethod.Type.Name;
        [OLVColumn(Title = "CompilationType", Width = 150)]
        public MethodCompilationType CompilationType => clrMethod.CompilationType;
        [OLVColumn(Title = "Signature", Width = 450)]
        public string Signature => clrMethod.GetFullSignature();
        [OLVColumn(Title = "IsAbstract", Width = 150)]
        public bool IsAbstract => clrMethod.IsAbstract;
        [OLVColumn(Title = "IsClassConstructor", Width = 150)]
        public bool IsClassConstructor => clrMethod.IsClassConstructor;
        [OLVColumn(Title = "IsConstructor", Width = 150)]
        public bool IsConstructor => clrMethod.IsConstructor;
        [OLVColumn(Title = "IsFinal", Width = 150)]
        public bool IsFinal => clrMethod.IsFinal;
        [OLVColumn(Title = "IsInternal", Width = 150)]
        public bool IsInternal => clrMethod.IsInternal;
        [OLVColumn(Title = "IsPInvoke", Width = 150)]
        public bool IsPInvoke => clrMethod.IsPInvoke;
        [OLVColumn(Title = "IsPrivate", Width = 150)]
        public bool IsPrivate => clrMethod.IsPrivate;
        [OLVColumn(Title = "IsProtected", Width = 150)]
        public bool IsProtected => clrMethod.IsProtected;
        [OLVColumn(Title = "IsPublic", Width = 150)]
        public bool IsPublic => clrMethod.IsPublic;
        [OLVColumn(Title = "IsStatic", Width = 150)]
        public bool IsStatic => clrMethod.IsStatic;
        [OLVColumn(Title = "IsVirtual", Width = 150)]
        public bool IsVirtual => clrMethod.IsVirtual;
    }
}