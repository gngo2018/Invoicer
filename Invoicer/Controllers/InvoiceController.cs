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
            var svc = CreateInvoiceService();
            var model = svc.GetInvoiceById(id);

            return View(model);
        }

        private InvoiceService CreateInvoiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceService(userId, _mapper);
            return svc;
        }
    }
}