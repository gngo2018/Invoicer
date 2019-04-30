using Invoicer.Data;
using Invoicer.Models.Invoice;
using Invoicer.Models.InvoiceTransaction;
using Invoicer.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Service
{
    public class InvoiceTransactionService
    {
        private readonly Guid _userId;

        public InvoiceTransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(InvoiceTransactionCreate model)
        {
            var entity = new InvoiceTransaction()
            {
                OwnerId = _userId,
                InvoiceId = model.InvoiceId,
                ProductId = model.ProductId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.InvoiceTransactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InvoiceTransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.InvoiceTransactions.Where(e => e.OwnerId == _userId)
                    .Select(e => new InvoiceTransactionListItem
                    {
                        InvoiceId = e.InvoiceId,
                        ProductId = e.ProductId,
                    });

                return query.ToArray();
            }
        }
        //TODO: Fix Delete Exception
        public InvoiceDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var invoice = ctx.Invoices.FirstOrDefault(t => t.InvoiceId == id && t.OwnerId == _userId);
                var query = ctx.InvoiceTransactions.Where(e => e.InvoiceId == id && e.OwnerId == _userId).ToArray();
                var products = new List<ProductListItem>();
                var runningTotal = 0m;
                foreach (InvoiceTransaction transaction in query)
                {
                    var product = ctx.Products.FirstOrDefault(e => e.ProductId == transaction.ProductId);
                    var newProduct = new ProductListItem
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        Quantity = product.Quantity,
                        TotalPrice = product.TotalPrice
                    };

                    products.Add(newProduct);

                    runningTotal += product.TotalPrice;
                }

                return new InvoiceDetail
                {
                    InvoiceId = invoice.InvoiceId,
                    BillAddress = invoice.BillAddress,
                    BillName = invoice.BillName,
                    CompanyName = invoice.CompanyName,
                    CompanyAddress = invoice.CompanyAddress,
                    CreatedUtc = invoice.CreatedUtc,
                    ProductList = products,
                    GrandTotal = runningTotal
                };
            }
        }

    }


}
