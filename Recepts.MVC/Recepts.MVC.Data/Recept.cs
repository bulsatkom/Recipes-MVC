using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.MVC.Data
{
    public class Recept
    {
        private ICollection<Product> products;
        private ICollection<Comment> comments;


        public Recept()
        {
            this.products = new HashSet<Product>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [Index(IsUnique = true)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [MinLength(3)]
        public string Descrption { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string Kitchen { get; set; }

        [Required]
        public int CookingTime { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }

        public DateTime? ReceptForDay { get; set; }

        public ICollection<Comment> Komentari
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        [Required]
        public int Views { get; set; }

        [Required]
        public int Likes { get; set; }
    }
}
