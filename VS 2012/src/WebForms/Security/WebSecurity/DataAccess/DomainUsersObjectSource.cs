using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using WebSecurity.Model;

namespace WebSecurity.DataAccess
{
    public class DomainUsersObjectSource
    {
        public IEnumerable<DomainUser> GetDomainUsers()
        {
            var context = HttpContext.Current;
            var cache = context.Cache;
            var domainUsers = cache["domainUsers"] as IEnumerable<DomainUser>;

            if (domainUsers == null)
            {
                domainUsers = Membership.GetAllUsers().OfType<MembershipUser>().Select(x => new DomainUser
                    {
                        Email = x.Email,
                        Username = x.UserName
                    });

                cache.Insert(
                    "domainUsers", // cache key
                    domainUsers, // object to cache
                    null, // dependencies
                    DateTime.Now.AddMinutes(30), // absoulute expiration
                    Cache.NoSlidingExpiration, // slading expiration
                    CacheItemPriority.High, // cache item priority
                    null // callback called when the cache item is removed
                );

                context.Trace.Warn("Data retrieved from its original source");
            }
            else
            {
                context.Trace.Warn("Data retrieved from cache");

            }

            return domainUsers;
        }
    }
}