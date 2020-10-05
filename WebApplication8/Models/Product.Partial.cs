using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    [ModelMetadataType(typeof(ProductMetadataType))]
    public partial class Product
    {       
    }

    public class ProductMetadataType
    {
        [Display(Name = "商品名稱")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "價格")]
        [Required]
        public decimal Price { get; set; }
    }
}
