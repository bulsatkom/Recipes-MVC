using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.MVC.Data
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid ReceptId { get; set; }
    }
}
