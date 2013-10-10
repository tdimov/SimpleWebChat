using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace SimpleWebChat.Hubs
{
    public class Chat : Hub
    {
        static int usersCount = 0;

        public void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "Hello :)";
            }

            string time = DateTime.UtcNow.AddHours(3).ToString("HH:mm:ss");
            string msg = string.Format("{0}: {1}", time, message.Replace("<", " ").Replace(">", " "));
            Clients.All.addMessage(msg);
        }

        public override Task OnConnected()
        {
            usersCount++;
            string newConnectedUserInfo = "One new user connected to the web chat at: " + DateTime.UtcNow.AddHours(3).ToString("HH:mm:ss");
            ShowUsersOnlineCount();
            ShowInfoForNewUserConnection(newConnectedUserInfo);
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            usersCount++;
            ShowUsersOnlineCount();
            return base.OnReconnected();
        }

        public override Task OnDisconnected()
        {
            usersCount--;
            string newConnectedUserInfo = "User disconnected from the web chat at: " + DateTime.UtcNow.AddHours(3).ToString("HH:mm:ss");
            ShowUsersOnlineCount();
            ShowInfoForNewUserConnection(newConnectedUserInfo);
            return base.OnDisconnected();
        }

        private void ShowInfoForNewUserConnection(string newConnectedUserInfo)
        {
            Clients.All.userConnection(newConnectedUserInfo);
        }

        public void ShowUsersOnlineCount()
        {
            Clients.All.showOnlineUsers(usersCount);
        }
    }
}