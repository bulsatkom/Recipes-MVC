using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recepts.MVC.Data;
using Bytes2you.Validation;

namespace Recepts_MVC_DataServices
{
    public class CommentService : ICommentService
    {
        private readonly IEfDbSetWrapper<Comment> DbContext;

        public CommentService(IEfDbSetWrapper<Comment> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public void AddComment(Guid id, string Comment, string author)
        {
            if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(Comment))
            {
                throw new ArgumentNullException();
            }

            var Com = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = Comment,
                Date = DateTime.Now,
                Author = author,
                ReceptId = id
            };

            this.DbContext.Add(Com);
            this.DbContext.SaveChanges();
        }

        public IEnumerable<Comment> GetCommentForRecept(Guid Id)
        {
            return this.DbContext.All.Where(c => c.ReceptId == Id).OrderByDescending(x => x.Date).ToList();
        }
    }
}
