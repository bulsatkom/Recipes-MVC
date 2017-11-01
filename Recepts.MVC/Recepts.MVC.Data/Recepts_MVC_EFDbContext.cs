using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Recepts.MVC.Data
{
    public class Recepts_MVC_EFDbContext : DbContext
    {
        public Recepts_MVC_EFDbContext()
            : base("DefaultConnection")
        {

        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Recept> Recept { get; set; }

        public IDbSet<Category> Category { get; set; }

        public IDbSet<Product> Product { get; set; }

        public IDbSet<Kusmeti> Kusmeti { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<CommentsForNovini> CommentsForNovini { get; set; }

        public IDbSet<Novini> Novini { get; set; }

        public IDbSet<Chat> Chat { get; set; }
    }
}
