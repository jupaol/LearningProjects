using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc4FirstBasicApplication.Models
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [MinLength(5)]
        [MaxLength(10)]
        public string NickName { get; set; }
        [Range(18, 80)]
        public int? Age { get; set; }
        public bool? WillAttend { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}