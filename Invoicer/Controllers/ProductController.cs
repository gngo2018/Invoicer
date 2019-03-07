using Invoicer.Models.Product;
using Invoicer.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invoicer.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var svc = CreateProductService();
            var model = svc.GetProducts();

            return View(model);
        }

        //GET: Product Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Invoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateProductService();

            if (svc.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Product was unable to be created");

            return View(model);
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ProductService(userId);
            return svc;
        }
    }
}