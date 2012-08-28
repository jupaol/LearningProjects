using SportsStore.Domain.Entities;
using SportsStore.UI.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI
{
    public static class BindersConfig
    {
        public static void RegisterBindings(ModelBinderDictionary binders)
        {
            binders.Add(typeof(Cart), new CartBinderModel());
        }
    }
}