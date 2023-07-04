using System;
using System.ComponentModel.DataAnnotations;

namespace Evoltis.DTOs
{
    public class ProductsCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Stock { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}

