using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SportsStore.Domain.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        public bool Authenticate(string username, string password)
        {
            bool res = FormsAuthentication.Authenticate(username, password);

            if (res)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return res;
        }

        public string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
