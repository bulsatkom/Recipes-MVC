using Recepts.MVC.ModelsBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class ReceptsViewModel
    {
        public Recept_Of_Day Recept { get; set; }

        public ICollection<ProductsForRecept> Products { get; set; }

        public ICollection<ReceptsFromCategory> MostViewReceptFromCategory { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}