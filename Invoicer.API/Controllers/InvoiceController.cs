using Invoicer.Models;
using Invoicer.Models.Invoice;
using Invoicer.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Invoicer.API.Controllers
{
    [Authorize]
    [EnableCorsAttribute("*", "*", "*")]
    public class InvoiceController : ApiController
    {
        //GET All Invoices
        public IHttpActionResult Get()
        {
            InvoiceService invoiceService = CreateInvoiceService();
            var invoices = invoiceService.GetInvoices();
            return Ok(invoices);
        }
        //GET Invoice by Id
        public IHttpActionResult Get(int id)
        {
            InvoiceTransactionService svc = CreateTransactionService();
            var invoice = svc.GetTransactionById(id);

            return Ok(invoice);
        }
        //POST Invoice Create
        [HttpPost]
        public IHttpActionResult CreateInvoice(InvoiceCreate invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateInvoiceService();

            if (!svc.CreateInvoice(invoice))
                return InternalServerError();

            return Ok("201");
        }
        //PUT Invoice Update
        [HttpPut]
        public IHttpActionResult UpdateInvoice(InvoiceEdit invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateInvoiceService();

            if (!svc.UpdateInvoice(invoice))
                return InternalServerError();

            return Ok("207");
        }
        //DELETE Invoice Delete
        public IHttpActionResult DeleteInvoice(int id)
        {
            var svc = CreateInvoiceService();

            if (!svc.DeleteInvoice(id))
                return InternalServerError();

            return Ok("202");
        }
        private InvoiceService CreateInvoiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var invoiceService = new InvoiceService(userId);

            return invoiceService;
        }

        private InvoiceTransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceTransactionService(userId);

            return svc;
        }
    }
}
