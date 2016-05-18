using System;
using System.Collections.Generic;
using WinFwk.UIMessages;
using WinFwk.UIServices;

namespace WinFwk.UICommands
{
    public class UICommandService : AbstractUIService,
        IMessageListener<UICommandRequest>
    {
        List<AbstractUICommand> commands;
        public override void Init(MessageBus messageBus)
        {
            base.Init(messageBus);
            // Get all the commands and instanciate them
            commands = new List<AbstractUICommand>();
            var types = WinFwkHelper.GetDerivedTypes(typeof(AbstractUICommand));
            foreach (var type in types)
            {
                var constructor = type.GetConstructor(Type.EmptyTypes);
                var command = constructor?.Invoke(null) as AbstractUICommand;
                if (command != null)
                {
                    command.InitBus(this.MessageBus);
                    commands.Add(command);
                }
            }
        }

        public void HandleMessage(UICommandRequest message)
        {
            message.Requestor.Accept(commands);
        }
    }
}
