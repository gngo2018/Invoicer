using AutoMapper;
using Invoicer.Models;
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
        private readonly InvoiceService _service;
        private readonly Guid _userId;

        // GET: All Invoice
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceService(userId, _mapper);
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

            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceService(userId, _mapper);

            svc.CreateInvoice(model);

            return RedirectToAction("Index");
        }

    }
}