using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;

namespace Msts
{
    public class CustomProfile : ProfileBase
    {
        public static CustomProfile GetCurrentProfile()
        {
            return HttpContext.Current.Profile as CustomProfile;
        }

        public static CustomProfile CreateProfile(string userID)
        {
            return ProfileBase.Create(userID) as CustomProfile;
        }

        [SettingsAllowAnonymous(true)]
        public string MasterPage
        {
            get
            {
                return this["MasterPage"] as string;
            }
            set
            {
                this["MasterPage"] = value;
            }
        }

        [SettingsAllowAnonymous(true)]
        public string Theme
        {
            get
            {
                return this["Theme"] as string;
            }
            set
            {
                this["Theme"] = value;
            }
        }

        [SettingsAllowAnonymous(allow: true)]
        public string Language
        {
            get
            {
                return this["Language"] as string;
            }
            set
            {
                this["Language"] = value;
            }
        }

        public DateTime? LastLogin
        {
            get
            {
                return this["LastLogin"] as DateTime?;
            }
            set
            {
                this["LastLogin"] = value;
            }
        }
    }
}