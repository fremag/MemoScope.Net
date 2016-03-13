using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoScope.Core.Dac
{
    public class DacFinder64 : AbstractDacFinder
    {
        private const string libDbghelpDll = "libs\\_x64\\dbghelp.dll";

        [DllImport(libDbghelpDll, EntryPoint = "SymInitialize", SetLastError = true)]
        private static extern bool SymInitialize64(IntPtr hProcess, string symPath, bool fInvadeProcess);

        [DllImport(libDbghelpDll, EntryPoint = "SymCleanup", SetLastError = true)]
        private static extern bool SymCleanup64(IntPtr hProcess);

        [DllImport(libDbghelpDll, EntryPoint = "SymFindFileInPath", SetLastError = true)]
        private static extern bool SymFindFileInPath64(IntPtr hProcess, string searchPath, string filename, uint id, uint two, uint three, uint flags, StringBuilder filePath, IntPtr callback, IntPtr context);


        public DacFinder64(string searchPath) : base(searchPath)
        {
        }

        protected override bool SymCleanup(IntPtr hProcess)
        {
            return SymCleanup64(hProcess);
        }

        protected override bool SymInitialize(IntPtr hProcess, string symPath, bool fInvadeProcess)
        {
            return SymInitialize64(hProcess, symPath, fInvadeProcess);
        }

        protected override void InitDbgHelpModule()
        {
            dbgHelpLib = LoadLibrary(libDbghelpDll);
        }

        protected override bool SymFindFileInPath(IntPtr hProcess, string searchPath, string filename, uint id, uint two, uint three, uint flags, StringBuilder filePath, IntPtr callback, IntPtr context)
        {
            return SymFindFileInPath64(hProcess, searchPath, filename, id, two, three, flags, filePath, callback, context);
        }
    }
}