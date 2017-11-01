using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class ChatViewModel
    {
        public IEnumerable<ChatModel> Messages { get; set; }
    }
}