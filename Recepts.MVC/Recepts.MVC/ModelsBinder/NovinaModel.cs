﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.ModelsBinder
{
    public class NovinaModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}