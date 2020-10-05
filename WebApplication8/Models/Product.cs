using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
