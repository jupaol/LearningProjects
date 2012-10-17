using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter12___Data_binding.Lesson03___Dynamic_Data
{
    public class JobMetadata
    {
        [Editable(false)]
        [Key]
        public object job_id { get; set; }

        [Required]
        public object job_desc { get; set; }

        [Required]
        [Range(10, 250)]
        public object min_lvl { get; set; }

        [Required]
        [Range(10, 250)]
        public object max_lvl { get; set; }
    }
}