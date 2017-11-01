using Recepts.MVC.ModelsBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class FilteredReceptsViewModel
    {
        public ICollection<ReceptsFromCategory> Recepts { get; set; }
    }
}