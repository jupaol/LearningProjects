using System;
using System.ComponentModel.DataAnnotations;

namespace ForeignKeys
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
