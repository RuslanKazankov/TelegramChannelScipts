using Microsoft.Extensions.Configuration;
using WTelegram;

namespace TelegramChannelScipts
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Braza!");

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfigurationRoot config = builder.Build();

            WTelegramConfiguration telegramConfiguration = config.GetSection(nameof(WTelegramConfiguration)).Get<WTelegramConfiguration>()!;

            WTelegram.Client client = new WTelegram.Client(telegramConfiguration.Config);

            var a = await client.LoginUserIfNeeded();

            Console.WriteLine("Welcome to Telegram, " + client.User.ID + "!");
        }
    }
}
