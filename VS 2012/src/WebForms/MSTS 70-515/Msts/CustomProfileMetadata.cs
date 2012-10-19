using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Msts
{
    public class CustomProfileMetadata
    {
        [ScaffoldColumn(false)]
        [Editable(false)]
        public object UserName { get; set; }

        [ScaffoldColumn(true)]
        public object MasterPage { get; set; }

        [ScaffoldColumn(true)]
        public object Language { get; set; }

        [ScaffoldColumn(true)]
        public object Theme { get; set; }

        [ScaffoldColumn(true)]
        [UIHint("CustomDateTime")]
        [DataType(DataType.Date)]
        public object LastLogin { get; set; }
    }
}
