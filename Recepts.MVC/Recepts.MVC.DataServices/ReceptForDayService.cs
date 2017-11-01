using Bytes2you.Validation;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recepts_MVC_DataServices
{
    public class ReceptForDayService : IReceptForDayService
    {
        private readonly IEfDbSetWrapper<Recept> DbContext;

        public ReceptForDayService(IEfDbSetWrapper<Recept> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public ICollection<Recept> TakeLatestRecepts()
        {
           var recepts =  this.DbContext.All.OrderByDescending(x => x.Date).Include(x => x.Category);

            if(recepts.Count() > 9)
            {
                return recepts.Take(9).ToList();
            }

            return recepts.ToList();
        }

        public void UpdateViewsById(Guid id)
        {
            var recept = this.GetByID(id);

            if (recept != null)
            {
                recept.Views += 1;
                this.DbContext.SaveChanges();
            }
        }

        public Recept GetByDate()
        {
            var date = DateTime.Now.Date;
            var recept = this.DbContext.AllWithInclude(x => x.Category).FirstOrDefault(x => x.ReceptForDay == date);

            return recept;
        }

        public Recept GetByID(Guid id)
        {
            Recept recept = this.DbContext.All.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            //recept.Category = this.DbContext.Category.FirstOrDefault(x => recept.CategoryId == x.Id);

            return recept;
        }

        public ICollection<Recept> TakeMostViewedRecepts()
        {
            var recepts = this.DbContext.AllWithInclude(x => x.Category).OrderByDescending(x => x.Views).Take(3).ToList();

            return recepts;
        }

        public ICollection<Recept> TakeMostViewReceptsFromCategoryByRecept(Recept recept)
        {
            var recepts = this.DbContext.All.Where(x => x.CategoryId == recept.CategoryId && recept.Id != x.Id).OrderByDescending(x => x.Views);

            if (recepts.Count() > 2)
            {
                return recepts.Take(2).ToList();
            }
            else
            {
                return recepts.ToList();
            }
           
        }

        public ICollection<Recept> TakeMost3ViewDeserts()
        {
            Guid desertId = Guid.Parse("D0AAF9A5-32F5-4147-B8CF-99B402051C51");
            var recepts = this.DbContext.All.Where(x => x.CategoryId == desertId).OrderByDescending(x => x.Views);
            if (recepts.Count() > 3)
            {
                return recepts.Take(3).ToList();
            }

            return recepts.ToList();
        }

        public ICollection<Recept> TakeMost3ViewOsnovni()
        {
            Guid osnovnoId = Guid.Parse("752099EC-3057-434A-A5E9-334D77C8FFB8");
            var recepts =  this.DbContext.All.Where(x => x.CategoryId == osnovnoId).OrderByDescending(x => x.Views);
            if (recepts.Count() > 3)
            {
                return recepts.Take(3).ToList();
            }

            return recepts.ToList();
        }

        public ICollection<Recept> TakeMost3ViewPredQstiq()
        {
            Guid predQstieId = Guid.Parse("79DAD09D-1ED0-4A77-9FD8-0BBEB75F283A");
            var recepts = this.DbContext.All.Where(x => x.CategoryId == predQstieId).OrderByDescending(x => x.Views);
            if (recepts.Count() > 3)
            {
                return recepts.Take(3).ToList();
            }

            return recepts.ToList();
        }

        public ICollection<Recept> TakeMost3ViewSupi()
        {
            Guid supaId = Guid.Parse("47CBCF17-0D40-477A-92B4-174C952885D7");
            var recepts = this.DbContext.All.Where(x => x.CategoryId == supaId).OrderByDescending(x => x.Views);
            if(recepts.Count() > 3)
            {
                return recepts.Take(3).ToList();
            }

            return recepts.ToList();
        }

        public ICollection<Recept> TakeAllRecepts()
        {
            return this.DbContext.All.OrderByDescending(x => x.Date).ToList();
        }

        public ICollection<Recept> TakeAllReceptsBySearchTerm(string searchTerm)
        {
            return this.DbContext.AllWithInclude(x => x.Category)
                .Where(x => x.Title.Contains(searchTerm) || x.Category.Name.Contains(searchTerm)).ToList();
        }
    }
}
