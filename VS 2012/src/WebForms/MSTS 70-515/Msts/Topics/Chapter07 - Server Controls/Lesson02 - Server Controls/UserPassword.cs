using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls
{
    //[ToolboxBitmap(typeof(UserPassword), "")]
    [ToolboxData("<{0}:UserPassword runat=server />")]
    [ToolboxItem(true)]
    [Description("User and password control")]
    [DefaultProperty("UserText")]
    [DefaultEvent("Authenticating")]
    [ParseChildren(false)]
    public class UserPassword : CompositeControl, INamingContainer
    {
        public UserPassword()
        {
            this.UserText = "Username:";
            this.PasswordText = "Password:";
            this.AuthenticateText = "Authenticate...";
        }

        [Description("The user text")]
        [Category("Apperacnce")]
        [DefaultValue("Username:")]
        [Bindable(true)]
        [Localizable(true)]
        [Browsable(true)]
        public string UserText
        {
            get
            {
                return (this.ViewState["UserText"] ?? string.Empty).ToString();
            }
            set
            {
                this.ViewState["UserText"] = value;
            }
        }

        [Description("Password text")]
        [DefaultValue("Password:")]
        [Category("Apperance")]
        [Bindable(true)]
        [Localizable(true)]
        [Browsable(true)]
        public string PasswordText
        {
            get
            {
                return (this.ViewState["PasswordText"] ?? string.Empty).ToString();
            }
            set
            {
                this.ViewState["PasswordText"] = value;
            }
        }

        [Description("Authenticate text")]
        [DefaultValue("Authenticate...")]
        [Category("Apperance")]
        [Bindable(true)]
        [Localizable(true)]
        [Browsable(true)]
        public string AuthenticateText
        {
            get
            {
                return (this.ViewState["AuthenticateText"] ?? string.Empty).ToString();
            }
            set
            {
                this.ViewState["AuthenticateText"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.ClearChildControlState();
            this.ClearChildViewState();
            this.TrackViewState();

            var panel = new Panel { ID = "panel" };
            var userMessage = new Label { ID = "userMessage", AssociatedControlID = "user", Text = this.UserText };
            var passwordMessage = new Label { ID = "passwordMessage", AssociatedControlID = "password", Text = this.PasswordText };
            var user = new TextBox { ID = "user" };
            var password = new TextBox { ID = "password", TextMode = TextBoxMode.Password };
            var authenticate = new Button { ID = "authenticate", Text = this.AuthenticateText };
            var resMessage = new Literal { ID = "resultMessage", Text = string.Empty };

            panel.Controls.Add(userMessage);
            panel.Controls.Add(user);
            panel.Controls.Add(new HtmlGenericControl("br"));
            panel.Controls.Add(passwordMessage);
            panel.Controls.Add(password);
            panel.Controls.Add(new HtmlGenericControl("br"));
            panel.Controls.Add(authenticate);
            panel.Controls.Add(new HtmlGenericControl("br"));
            panel.Controls.Add(new HtmlGenericControl("hr"));
            panel.Controls.Add(resMessage);

            this.Controls.Add(panel);

            authenticate.Click += authenticate_Click;

            this.ChildControlsCreated = true;
        }

        private void authenticate_Click(object sender, EventArgs e)
        {
            var user = this.FindControl("panel").FindControl("user") as TextBox;
            var password = this.FindControl("panel").FindControl("password") as TextBox;
            var res = this.FindControl("panel").FindControl("resultMessage") as Literal;

            if (user.Text.Equals("user", StringComparison.InvariantCulture) && password.Text.Equals("password!", StringComparison.InvariantCulture))
            {
                res.Text = string.Format("The authentication result is: 'authenticated'");
            }
            else
            {
                res.Text = string.Format("The authentication result is: 'not authenticated'");
            }
        }
    }
}