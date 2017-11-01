using Recepts.MVC.ModelsBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class NovinaViewModel
    {
        public NovinaModel novina { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}