using Bytes2you.Validation;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recepts_MVC_DataServices
{
    public class ProductService : IProductService
    {
        private readonly IEfDbSetWrapper<Product> DbContext;

        public ProductService(IEfDbSetWrapper<Product> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public ICollection<Product> GetProductForReceptById(Guid id)
        {
            return this.DbContext.All.Where(x => x.ReceptId == id).ToList();
        }
    }
}
