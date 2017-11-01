using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.MVC.DataServices
{
    public interface ICommentsForNoviniService
    {
        IEnumerable<CommentsForNovini> GetCommentForNovina(Guid Id);

        void AddCommentForNovina(Guid id, string Comment, string author);
    }
}
