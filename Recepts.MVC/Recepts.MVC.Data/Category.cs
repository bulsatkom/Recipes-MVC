using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepts.MVC.Data
{
    public class Category
    {
        [Index(IsUnique = true)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}