using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public abstract class BaseMasterPage : MasterPage
    {
        public BaseMasterPage()
        {
            this.Load += BaseMasterPage_Load;
            this.PreRender += BaseMasterPage_PreRender;
        }

        private void BaseMasterPage_PreRender(object sender, EventArgs e)
        {
            var profile = CustomProfile.GetCurrentProfile();

            if (profile != null)
            {
                var layouts = this.AvailableLayouts;
                var themes = this.AvailableThemes;
                var languages = this.AvailableLanguages;

                if (layouts != null)
                {
                    var masterPage = profile.MasterPage;

                    if (!string.IsNullOrWhiteSpace(masterPage))
                    {
                        layouts.SelectedValue = masterPage;
                    }
                }

                if (themes != null)
                {
                    var theme = profile.Theme;

                    if (!string.IsNullOrWhiteSpace(theme))
                    {
                        themes.SelectedValue = theme;
                    }
                }

                if (languages != null)
                {
                    var language = profile.Language;

                    if (!string.IsNullOrWhiteSpace(language))
                    {
                        languages.SelectedValue = language;
                    }
                }
            }
        }

        private void BaseMasterPage_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.AvailableLanguages != null)
                {
                    var languages = CultureInfo.GetCultures(CultureTypes.NeutralCultures);

                    this.AvailableLanguages.DataSource = languages;
                    this.AvailableLanguages.DataTextField = "DisplayName";
                    this.AvailableLanguages.DataValueField = "Name";
                    //this.AvailableLanguages.DataBind();
                }
            }
        }

        public string CurrentMasterPage { get; set; }
        protected abstract DropDownList AvailableLayouts { get; }
        protected virtual DropDownList AvailableLanguages
        {
            get
            {
                return null;
            }
        }

        protected virtual DropDownList AvailableThemes
        {
            get
            {
                return null;
            }
        }

        public virtual string CurrentTitle
        {
            get
            {
                return string.Empty;
            }
        }

        protected void ddlLayouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = CustomProfile.GetCurrentProfile();
            var ddlLayouts = sender as DropDownList;

            if (profile == null)
            {
                throw new ApplicationException("The profile could not be loaded");
            }

            if (ddlLayouts == null)
            {
                throw new ApplicationException("The event source is incorrect");
            }

            profile.MasterPage = ddlLayouts.SelectedValue;
            profile.Save();

            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void ddlThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var themes = sender as DropDownList;

            if (themes == null)
            {
                throw new ArgumentException("sender");
            }

            var profile = CustomProfile.GetCurrentProfile();

            if (profile == null)
            {
                throw new ApplicationException("The profile could not be loaded");
            }

            var theme = themes.SelectedValue;

            if (string.IsNullOrWhiteSpace(theme))
            {
                throw new ArgumentNullException("SelectedValue");
            }

            switch (theme.ToLowerInvariant())
            {
                case "blue":
                case "red":
                case "yellow":
                    profile.Theme = theme;
                    profile.Save();

                    this.Response.Redirect(this.Request.RawUrl);
                    break;
                default:
                    throw new ArgumentException("SelectedValue");
            }
        }

        protected void ddlCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlCultures = this.AvailableLanguages;

            if (ddlCultures == null)
            {
                throw new InvalidOperationException("The cultures DropDownList is not defined");
            }

            var profile = this.Context.Profile as CustomProfile;

            if (profile == null)
            {
                throw new InvalidOperationException("The profile was not found");
            }

            var language = ddlCultures.SelectedValue;

            switch (language.ToLowerInvariant())
            {
                case "en":
                case "es":
                    break;
                default:
                    throw new SecurityException("A possible temper attempt has been blocked");
            }

            profile.Language = language;
            profile.Save();

            Response.Redirect(this.Request.RawUrl);
        }
    }
}