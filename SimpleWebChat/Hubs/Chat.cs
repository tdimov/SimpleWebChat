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
            string username = Environment.MachineName.Substring(0, Environment.MachineName.Length - 3); //cut -PC from computer name
            string msg = string.Format("{0}: {1}", username, message.Replace("<", " ").Replace(">", " "));
            Clients.All.addMessage(msg);
        }
    }
}