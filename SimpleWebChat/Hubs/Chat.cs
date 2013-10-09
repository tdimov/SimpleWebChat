using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SimpleWebChat.Hubs
{
    public class Chat : Hub
    {
        public void SendMessage(string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string msg = string.Format("{0}: {1}", time, message.Replace("<", " ").Replace(">", " "));
            Clients.All.addMessage(msg);
        }
    }
}