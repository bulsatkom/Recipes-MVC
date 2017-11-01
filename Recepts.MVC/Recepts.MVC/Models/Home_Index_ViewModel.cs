using Recepts.MVC.ModelsBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class Home_Index_ViewModel
    {
        public string Hello { get; set; }

        public Recept_Of_Day ReceptOfDay { get; set; }

        public string KusmetOfDay { get; set; }

        public ICollection<Recept_Of_Day> LatestRecepts { get; set; }

        public ICollection<Recept_Of_Day> MostViewRecepts { get; set; }

        public ICollection<NoviniModel> Novini { get; set; }

        public ICollection<ReceptsFromCategory> DessertRecepts { get; set; }

        public ICollection<ReceptsFromCategory> SupaRecepts { get; set; }

        public ICollection<ReceptsFromCategory> OsnovnoRecepts { get; set; }

        public ICollection<ReceptsFromCategory> PredQstieRecepts { get; set; }

    }
}