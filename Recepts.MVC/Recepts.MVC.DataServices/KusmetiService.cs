using Bytes2you.Validation;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts_MVC_DataServices
{
    public class KusmetiService : IKusmetiService
    {
        private readonly IEfDbSetWrapper<Kusmeti> DbContext;

        public KusmetiService(IEfDbSetWrapper<Kusmeti> DbContext)
        {
            Guard.WhenArgument(DbContext, "DbContext").IsNull().Throw();

            this.DbContext = DbContext;
        }

        public string GetKusmetForToday()
        {
            var date = DateTime.Now.Date;
            var result = this.DbContext.All.Where(x => x.Date == date).Select(x => x.Kusmet).FirstOrDefault();

            if(result != null)
            {
                return result.ToString();
            }

            return null;
        }
    }
}
