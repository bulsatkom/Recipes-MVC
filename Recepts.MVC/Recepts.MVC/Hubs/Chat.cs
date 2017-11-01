using Microsoft.AspNet.SignalR;
using Recepts_MVC_DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Hubs
{
    public class Chat : Hub
    {
        private readonly IChatService chatservice;

        public Chat(IChatService chatservice)
        {
            this.chatservice = chatservice;
        }

        public void SendMessage(string message)
        {
            var date = DateTime.Now.Date;
            var author = this.Context.User.Identity.Name;
            string receivedmessage = string.Format("{0} at {1} : {2}", author, date, message);
            this.Clients.All.receiveMessage(receivedmessage);

            this.chatservice.AddChatMessage(author, message);
        }
    }
}