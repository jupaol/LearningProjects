using System;
using System.ComponentModel.DataAnnotations;

namespace ForeignKeys
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
