using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramChannelScipts.Services;
using Microsoft.VisualBasic.CompilerServices;
using TL;

namespace TelegramChannelScipts.Menu
{
    public class MainMenu
    {
        private List<CommandMenu> commands;
        public MainMenu(PostService postService) 
        {
            commands = new()
            {
                new CommandMenu("Список администрируемых каналов", async () =>
                {
                    await postService.WriteAllAdminedChannelsAsync();
                }),
                new CommandMenu("Список постов", async () =>
                {
                    await Console.Out.WriteLineAsync("Channel id: ");
                    long a = long.Parse(Console.ReadLine());
                    Messages_MessagesBase messages = await postService.GetPostsAsync(Conversions.ToLong(a));
                    var history = messages.Messages;
                    for (int i = 0; i < messages.Count; i++)
                    {
                        await Console.Out.WriteLineAsync(history[i].ToString());
                    }
                }),
            };
        }

        public string GetTextMenu()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < commands.Count; i++)
            {
                sb.AppendLine($"{i}. {commands[i].CommandTitle}");
            }
            return sb.ToString();
        }

        public void ExecuteCommand(int commandId)
        {
            try
            {
                commands[commandId].Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(GetTextMenu());
            }
        }


    }
}
