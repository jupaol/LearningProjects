using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter05.Lesson02
{
    public class BasePreviousPage : Page
    {
        public string MyText
        {
            get
            {
                if (this.MyTextBox == null)
                {
                    throw new InvalidOperationException();
                }

                return this.MyTextBox.Text;
            }
            set
            {
                if (this.MyTextBox == null)
                {
                    throw new InvalidOperationException();
                }

                this.MyTextBox.Text = value;
            }
        }

        protected virtual TextBox MyTextBox
        {
            get;
            private set;
        }
    }
}