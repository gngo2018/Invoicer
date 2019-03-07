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

        //GET Invoice by ID
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        //GET Invoice Edit
        public ActionResult Edit(int id)
        {
            var svc = CreateProductService();
            var detail = svc.GetProductById(id);
            var model = new ProductEdit
            {
                ProductId = detail.ProductId,
                ProductName = detail.ProductName,
                ProductPrice = detail.ProductPrice,
                Quantity = detail.Quantity
            };

            return View(model);
        }

        //PUT Invoice Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = CreateProductService();

            if (svc.UpdateInvoice(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your invoice could not be updated.");
            return View(model);
        }

        //GET Invoice Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        //POST Invoice Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateProductService();

            svc.DeleteProduct(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ProductService(userId);
            return svc;
        }
    }
}