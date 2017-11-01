using Bytes2you.Validation;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recepts_MVC_DataServices
{
    public class NoviniService : INoviniService
    {
        private readonly IEfDbSetWrapper<Novini> DbContext;

        public NoviniService(IEfDbSetWrapper<Novini> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public ICollection<Novini> TakeAllNovini()
        {
            return this.DbContext.All.OrderByDescending(x => x.Date).ToList();
        }

        public ICollection<Novini> TakeLatest5Novini()
        {
            var novini = this.DbContext.All.OrderByDescending(x => x.Date);
            if(novini.Count() > 5)
            {
                return novini.Take(5).ToList();
            }

            return novini.ToList();
        }

        public Novini TakeNovinaById(Guid id)
        {
            return this.DbContext.GetById(id);
        }
    }
}
