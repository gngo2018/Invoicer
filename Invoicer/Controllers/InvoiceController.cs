using AutoMapper;
using Invoicer.Models;
using Invoicer.Models.Invoice;
using Invoicer.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invoicer.Controllers
{
    //[Authorize]
    public class InvoiceController : Controller
    {
        private readonly IMapper _mapper;
        // GET: All Invoice
        public ActionResult Index()
        {
            var svc = CreateInvoiceService();
            var model = svc.GetInvoices();

            return View(model);
        }

        //GET: Invoice Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Invoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateInvoiceService();

            if (svc.CreateInvoice(model))
            {
                TempData["SaveResult"] = "Your invoice was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Invoice was unable to be created");

            return View(model);
        }

        //GET Invoice by ID
        public ActionResult Details (int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        //GET Invoice Edit
        public ActionResult Edit (int id)
        {
            var svc = CreateInvoiceService();
            var detail = svc.GetInvoiceById(id);
            var model = new InvoiceEdit
            {
                InvoiceId = detail.InvoiceId,
                CompanyName = detail.CompanyName,
                CompanyAddress = detail.CompanyAddress,
                BillName = detail.BillName,
                BillAddress = detail.BillAddress
            };

            return View(model);
        }

        //PUT Invoice Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InvoiceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.InvoiceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = CreateInvoiceService();

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
            var svc = CreateInvoiceService();
            var model = svc.GetInvoiceById(id);

            return View(model);
        }

        //POST Invoice Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateInvoiceService();

            svc.DeleteInvoice(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private InvoiceService CreateInvoiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceService(userId, _mapper);
            return svc;
        }

        private InvoiceTransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceTransactionService(userId);
            return svc;
        }
    }
}