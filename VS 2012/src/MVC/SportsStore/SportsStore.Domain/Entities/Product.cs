using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web.Mvc;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        [DataType(DataType.Upload)]
        public byte[] ImageData { get; set; }

        [HiddenInput]
        public string ImageMimeType { get; set; }
    }
}
