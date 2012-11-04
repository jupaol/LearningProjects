using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Msts.Mvc.Models;

namespace Msts.Mvc
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "00000000480DDA42",
                clientSecret: "sJ7x8py-mvo45tHaEFX8dunNEQXVQfGc",
                displayName: "Microsoft",
                extraData: new Dictionary<string, object> { { "Icon", "~/Images/live.jpg" } });

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "jspfwqPm4kvtwpt8PppBBA",
                consumerSecret: "RJIwjgW6Bo4wUNr32nlCOIcISipv5Hi2NTu4u6kMrts",
                displayName: "Twitter",
                extraData: new Dictionary<string, object> { { "Icon", "~/Images/twitter.png" } });

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "459944857377239",
                appSecret: "e05079e0019192399422c81c2bddbeb5",
                displayName: "Facebook",
                extraData: new Dictionary<string, object> { { "Icon", "~/Images/facebook.jpg" } });

            OAuthWebSecurity.RegisterGoogleClient(
                displayName: "Google",
                extraData: new Dictionary<string, object> { { "Icon", "~/Images/google.png" } });
        }
    }
}
