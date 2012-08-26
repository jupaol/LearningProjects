using AutoMapper;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.Controllers
{
    public partial class ProductController : Controller
    {
        private IProductRepository productRepository;
        private int pageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public virtual ActionResult List(int page = 1)
        {
            var products = this.productRepository.GetProducts();

            var q = products
                .OrderBy(x => x.ProductID)
                .Skip((page -1) * pageSize)
                .Take(pageSize);

            return View(new ProductsListViewModel
            {
                Products = q, 
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page, 
                    ItemsPerPage = this.pageSize, 
                    TotalItems = products.Count() 
                } 
            });
        }
    }
}
