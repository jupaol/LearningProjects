using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson01___User_Controls
{
    [ToolboxItem(false)]
    public class TemplatedAddressContainer : Control, INamingContainer
    {
        public string Street { get; protected set; }

        public TemplatedAddressContainer(string street)
        {
            this.Street = street;
        }
    }
}