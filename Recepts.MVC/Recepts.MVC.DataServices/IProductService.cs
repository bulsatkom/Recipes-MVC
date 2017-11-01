using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts_MVC_DataServices
{
    public interface IProductService
    {
        ICollection<Product> GetProductForReceptById(Guid id);
    }
}
