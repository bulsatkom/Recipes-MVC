using Recepts.MVC.ModelsBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class NoviniViewModel
    {
       public ICollection<NoviniModel> Novini { get; set; }
    }
}