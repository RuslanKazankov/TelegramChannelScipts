using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramChannelScipts.Menu
{
    public class CommandMenu
    {
        public delegate Task Command();
        public string CommandTitle { get; private set; }

        private Command _command;

        public CommandMenu(string title, Command command)
        {
            CommandTitle = title;
            _command = command;
        }

        public void Execute()
        {
            _command();
        }
    }
}
