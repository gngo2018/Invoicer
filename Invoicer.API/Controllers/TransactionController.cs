using Invoicer.Models.InvoiceTransaction;
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
    [EnableCorsAttribute("*", "*", "*")]
    public class TransactionController : ApiController
    {
        //GET All Productss
        public IHttpActionResult Get()
        {
            InvoiceTransactionService svc = CreateTransactionService();
            var transactions = svc.GetTransactions();
            return Ok(transactions);
        }

        //POST Product Create
        [HttpPost]
        public IHttpActionResult CreateProduct(InvoiceTransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateTransactionService();

            if (!svc.CreateTransaction(transaction))
                return InternalServerError();

            return Ok("201");
        }

        private InvoiceTransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InvoiceTransactionService(userId);

            return svc;
        }
    }
}
