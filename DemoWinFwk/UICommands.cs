using System;
using System.Diagnostics;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace DemoWinFwk
{
    public class StringTypedUiCommand : AbstractTypedUICommand<String>
    {
        public StringTypedUiCommand() : base("String", "Some string", "Data", null)
        {
        }

        protected override void HandleData(string data)
        {
            Debug.WriteLine(GetType());
        }
    }

    public class TextTypedUiCommand : AbstractTypedUICommand<String>
    {
        public TextTypedUiCommand() : base("Text", "Some text", "Text", null)
        {
        }

        protected override void HandleData(string data)
        {
            Debug.WriteLine(GetType());
        }
    }

    public class DoubleTypedUiCommands : AbstractTypedUICommand<double>
    {
        public DoubleTypedUiCommands() : base("Double", "Some double", "Data", null)
        {
        }

        protected override void HandleData(double data)
        {
            Debug.WriteLine(GetType());
        }
    }

    public class TotoCommand : AbstractVoidUICommand
    {
        public TotoCommand() : base("Toto", "toto command", "File", null)
        {
        }

        public override void Run()
        {
            MessageBus.SendMessage(new DockRequest(new StringModule()));
        }
    }
}