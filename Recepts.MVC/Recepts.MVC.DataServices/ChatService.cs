using Bytes2you.Validation;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts_MVC_DataServices
{
    public class ChatService : IChatService
    {
        private readonly IEfDbSetWrapper<Chat> DbContext;

        public ChatService(IEfDbSetWrapper<Chat> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public ICollection<Chat> GetLatest30Messages()
        {
            var messages = this.DbContext.All.OrderByDescending(x => x.Date);

            if(messages.Count() > 30)
            {
                return messages.Take(30).ToList();
            }
            else
            {
                return messages.ToList();
            }
        }

        public void AddChatMessage(string author, string content)
        {
            if(string.IsNullOrEmpty(author) || string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException();
            }

            var message = new Chat()
            {
                Id = Guid.NewGuid(),
                Author = author,
                Content = content,
                Date = DateTime.Now
            };

            this.DbContext.Add(message);
            this.DbContext.SaveChanges();
        }
    }
}
