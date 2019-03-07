using Invoicer.Models.InvoiceTransaction;
using Invoicer.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invoicer.Controllers
{
    public class InvoiceTransactionController : Controller
    {
        // GET: InvoiceTransaction
        public ActionResult Index()
        {
            var svc = CreateInvoiceTransactionService();
            var model = svc.GetTransactions();
            return View(model);
        }

        //GET: Transaction Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Transaction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceTransactionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateInvoiceTransactionService();

            if (svc.CreateTransaction(model))
            {
                TempData["SaveResult"] = "Your product was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Product was unable to be created");

            return View(model);
        }

        private InvoiceTransactionService CreateInvoiceTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceTransactionService(userId);
            return svc;
        }
    }
}