using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls
{
    [ToolboxItem(false)]
    public class TemplatedServerAddressContainer : WebControl, INamingContainer
    {
        public string Address { get; protected set; }

        public TemplatedServerAddressContainer(string address)
        {
            this.Address = address;
        }
    }
}