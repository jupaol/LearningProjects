using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.UI.Areas.Administration.Models;
using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.Areas.Administration.Controllers
{
    [Authorize]
    public partial class AdminController : Controller
    {
        private IProductRepository productRepository;
        private const int pageSize = 4;

        public AdminController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public virtual ActionResult List(int page = 1)
        {
            var products = this.productRepository.GetProducts();
            var pagedProducts = products
                .OrderBy(x => x.ProductID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return View(new AdminProductModel
            {
                Products = pagedProducts,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count()
                }
            });
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var products = this.productRepository.GetProducts();
            var product = products.FirstOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                throw new IndexOutOfRangeException("Product not found");
            }

            return View(product);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var products = this.productRepository.GetProducts();
            var product = products.FirstOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                throw new IndexOutOfRangeException("Product not found");
            }

            return View(product);
        }

        [HttpPost]
        public virtual ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            var products = this.productRepository.GetProducts();

            if (products.FirstOrDefault(x => x.ProductID == product.ProductID) == null)
            {
                throw new IndexOutOfRangeException("Product not found");
            }

            if (!this.ModelState.IsValid)
            {
                return View(product);
            }

            if (image != null)
            {
                product.ImageMimeType = image.ContentType;
                product.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(product.ImageData, 0, image.ContentLength);
            }

            this.productRepository.UpdateProduct(product);

            this.TempData["message"] = string.Format("The product {0} with id {1} was updated successfuly", product.Name, product.ProductID);

            return RedirectToAction(MVC.Administration.Admin.Details(product.ProductID));
        }

        public virtual ActionResult Delete(int id)
        {
            var products = this.productRepository.GetProducts();
            var product = products.FirstOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                throw new IndexOutOfRangeException("Product not found");
            }

            this.productRepository.Delete(id);

            return RedirectToAction(MVC.Administration.Admin.List());
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(Product product)
        {
            if (!this.ModelState.IsValid)
            {
                return View(product);
            }

            this.productRepository.Add(product);

            this.TempData["message"] = string.Format("The product: {0} was created with the id: {1} successfuly", product.Name, product.ProductID);

            return RedirectToAction(MVC.Administration.Admin.Details(product.ProductID));
        }
    }
}
