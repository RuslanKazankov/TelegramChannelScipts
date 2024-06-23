using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;

namespace TelegramChannelScipts.Services
{
    public class PostService
    {
        private readonly Client _client;
        public PostService(Client client)
        {
            _client = client;
        }

        public async Task WriteAllAdminedChannelsAsync()
        {
            Messages_Chats chats = await _client.Channels_GetAdminedPublicChannels();
            foreach (KeyValuePair<long, ChatBase> chat in chats.chats)
            {
                Console.WriteLine($"chat: {chat.Key} | {chat.Value.Title}");
            }

        }

        public async Task<Messages_MessagesBase> GetPostsAsync(long chatId)
        {
            Messages_Chats chats = await _client.Channels_GetAdminedPublicChannels();
            return await _client.Messages_GetHistory(chats.chats[chatId]);
        }
    }
}
