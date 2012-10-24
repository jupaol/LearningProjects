using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Msts.Mvc.Models
{
    public class SimpleValidationModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string FirstName { get; set; }
    }
}