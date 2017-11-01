using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepts.MVC.Data
{
    public class Product
    {
        [Required]
        [Index(IsUnique = true)]
        public Guid Id { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid ReceptId { get; set; }
    }
}