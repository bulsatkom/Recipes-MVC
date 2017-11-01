using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.Models
{
    public class Recept_Of_Day
    {
        public Recept_Of_Day()
        {

        }

        public Recept_Of_Day(Recept recept)
        {
            if (recept != null)
            {
                this.Id = recept.Id;
                this.Title = recept.Title;
                this.Image = recept.Image;
                this.Descrption = recept.Descrption;
                this.Date = recept.Date;
                this.Kitchen = recept.Kitchen;
                this.CookingTime = recept.CookingTime;
                var name = recept.Category.Name;
                this.Type = name;
                this.Products = new List<Product>();
                this.Views = recept.Views;
                this.Likes = recept.Likes;
                foreach (var product in recept.Products)
                {
                    this.Products.Add(product);
                }       
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Descrption { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string Kitchen { get; set; }

        public int CookingTime { get; set; }

        public ICollection<Product> Products { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }
    }
}