using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts_MVC_DataServices
{
    public interface IChatService
    {
        ICollection<Chat> GetLatest30Messages();
        void AddChatMessage(string author, string content);
    }
}
