using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.UI.Models
{
    public class CartModel
    {
        public Cart Cart{ get; set; }
        public string ReturnUrl { get; set; }
    }
}