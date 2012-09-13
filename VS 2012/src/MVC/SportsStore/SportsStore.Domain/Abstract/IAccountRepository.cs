using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public interface IAccountRepository
    {
        bool Authenticate(string username, string password);

        string GetCurrentUser();

        void Logout();
    }
}
