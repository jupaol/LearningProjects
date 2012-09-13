using SportsStore.Domain.Entities;
using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.UI.Areas.Administration.Models
{
    public class AdminProductModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}