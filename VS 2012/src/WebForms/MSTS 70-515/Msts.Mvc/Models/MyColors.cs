using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Msts.Mvc.Models
{
    public enum MyColors
    {
        [Description("Red color")]
        Red,

        [Description("Green color")]
        Greem,

        [Description("Yellow color")]
        Yellow,

        Blue
    }
}