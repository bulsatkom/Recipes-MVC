using Recepts.MVC.Data;
using System;
using System.Collections.Generic;

namespace Recepts_MVC_DataServices
{
    public interface IReceptForDayService
    {
        Recept GetByDate();

        Recept GetByID(Guid id);

        void UpdateViewsById(Guid id);

        ICollection<Recept> TakeLatestRecepts();

        ICollection<Recept> TakeMostViewedRecepts();

        ICollection<Recept> TakeMostViewReceptsFromCategoryByRecept(Recept recept);

        ICollection<Recept> TakeMost3ViewDeserts();

        ICollection<Recept> TakeMost3ViewOsnovni();

        ICollection<Recept> TakeMost3ViewPredQstiq();

        ICollection<Recept> TakeMost3ViewSupi();

        ICollection<Recept> TakeAllRecepts();

        ICollection<Recept> TakeAllReceptsBySearchTerm(string searchTerm);
    }
}
