using System;
using System.Diagnostics;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace DemoWinFwk
{
    public class StringUICommand : AbstractUICommand<String>
    {
        public StringUICommand() : base("String", "Some string", "Data", null)
        {
        }

        protected override void HandleData(string data)
        {
            Debug.WriteLine(GetType());
        }
    }

    public class TextUICommand : AbstractUICommand<String>
    {
        public TextUICommand() : base("Text", "Some text", "Text", null)
        {
        }

        protected override void HandleData(string data)
        {
            Debug.WriteLine(GetType());
        }
    }

    public class DoubleUICommands : AbstractUICommand<double>
    {
        public DoubleUICommands() : base("Double", "Some double", "Data", null)
        {
        }

        protected override void HandleData(double data)
        {
            Debug.WriteLine(GetType());
        }
    }

    public class TotoCommand : AbstractUICommand<object>
    {
        public TotoCommand() : base("Toto", "toto command", "File", null)
        {
        }

        protected override void HandleData(object data)
        {
            MessageBus.SendMessage(new DockRequest(new StringModule()));
        }
    }
}