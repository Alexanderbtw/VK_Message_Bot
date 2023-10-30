using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VK_Mes_ModelLib
{
    public static class Utility
    {
        private static string Token = "vk1.a.mk8o8gI5OP8XeZMd_-EAjJlJhPGpslLJbM7yNrt_Fi5AgSV6ZhzYSU1JJe6W2aLSz_bTHyA7Au35Aen6uGocBJw5E47EOcduHdBwMT8Ce6KbuUfCYZe9YzQwDzQIZ90UxpF6b3fsP_lbkPq6ziPCMCrki-QfJkeTnhPL1BRMhdLKnG7SPKuNcPWjqQxbjq3slM0kuVb5vhbHOC_XSUMWVA";
        private static VkApi api = new VkApi();
        private static long mesRandId = 0;
        public static event Action<UserInfo>? Log;

        public static void Initialize()
        {
            api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });
        }

        public static async Task StartReceiving()
        {
            while (true)
            {
                await Task.Run(() => GetMessages());
            }
        }

        private static void GetMessages()
        {
            string mes;
            long? userID;
            var messages = api.Messages.GetConversations(new GetConversationsParams());

            if (messages.UnreadCount > 0)
            {
                mes = messages.Items[0].LastMessage.Text;
                userID = messages.Items[0].LastMessage.UserId;
                //Log?.Invoke(new UserInfo { id = userID, message = mes });
                api.Messages.Send(new MessagesSendParams { Message = mes, UserId = userID, RandomId = mesRandId++ });
            }
        }
    }
}
