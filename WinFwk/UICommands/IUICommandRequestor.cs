using System.Collections.Generic;

namespace WinFwk.UICommands
{
    public interface IUICommandRequestor
    {
        void Accept(IEnumerable<AbstractUICommand> commands);
    }
}
