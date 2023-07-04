using System;
using System.ComponentModel.DataAnnotations;

namespace Evoltis.DTOs
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public DateTime Date { get; set; }
    }
}

