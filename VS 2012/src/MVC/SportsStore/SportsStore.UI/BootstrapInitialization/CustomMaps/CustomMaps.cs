using AutoMapper;
using Bootstrap.AutoMapper;
using SportsStore.Domain.Entities;
using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.UI.BootstrapInitialization.CustomMaps
{
    public class CustomMaps : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<Product, ProductModel>();
        }
    }
}