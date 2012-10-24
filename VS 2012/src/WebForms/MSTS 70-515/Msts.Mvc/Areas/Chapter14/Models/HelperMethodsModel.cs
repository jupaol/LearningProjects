using Msts.Domain;
using Msts.Mvc.DataAccess.EFData;
using Msts.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Areas.Chapter14.Models
{
    public class HelperMethodsModel
    {
        public HelperMethodsModel()
        {
            this.SelectedJobs = Enumerable.Empty<Int16>().ToArray();
            this.Jobs = Enumerable.Empty<job>();
        }

        public bool IsAccepted { get; set; }

        public IEnumerable<job> Jobs { get; set; }
        public string SelectedJob { get; set; }

        public string JobDescription { get; set; }

        [HiddenInput]
        public Int16 ID { get; set; }

        [ReadOnly(true)]
        public Int16 JobID { get; set; }

        public Int16[] SelectedJobs { get; set; }

        public string Password { get; set; }

        public string FavoriteColor { get; set; }

        public MyColors MyColor { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string SimpleTextbox { get; set; }

        public string SimpleTextArea { get; set; }

        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [DataType(DataType.Currency)]
        public decimal Currency { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Welcome_Message", ResourceType = typeof(GlobalResources))]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Html)]
        public string HtmlText { get; set; }
    }
}