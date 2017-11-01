using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class ChatModel
    {
        public ChatModel(Chat chat)
        {
            this.Author = chat.Author;
            this.Date = chat.Date;
            this.Content = chat.Content;
        }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}