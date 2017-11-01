using Bytes2you.Validation;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.MVC.DataServices
{
    public class CommentsForNoviniService : ICommentsForNoviniService
    {
        private readonly IEfDbSetWrapper<CommentsForNovini> DbContext;

        public CommentsForNoviniService(IEfDbSetWrapper<CommentsForNovini> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public void AddCommentForNovina(Guid id, string Comment, string author)
        {
            if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(Comment))
            {
                throw new ArgumentNullException();
            }

            var Com = new CommentsForNovini()
            {
                Id = Guid.NewGuid(),
                Content = Comment,
                Date = DateTime.Now,
                Author = author,
                NoviniId = id
            };

            this.DbContext.Add(Com);
            this.DbContext.SaveChanges();
        }

        public IEnumerable<CommentsForNovini> GetCommentForNovina(Guid Id)
        {
            return this.DbContext.All.Where(c => c.NoviniId == Id).OrderByDescending(x => x.Date).ToList();
        }
    }
}
