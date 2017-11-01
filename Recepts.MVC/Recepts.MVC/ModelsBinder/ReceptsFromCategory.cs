using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.ModelsBinder
{
    public class ReceptsFromCategory
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }
    }
}