using System;
using System.ComponentModel.DataAnnotations;

namespace Evoltis.Entities.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Category { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

    }
}

