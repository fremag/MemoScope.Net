using System.Collections.Generic;

namespace WinFwk.UITools.Commands
{
    public interface IDataExportable
    {
        IEnumerable<string> ExportableData();
    }
}