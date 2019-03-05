using AutoMapper;
using Invoicer.Data;
using Invoicer.Models;
using Invoicer.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Service
{
    public class InvoiceService
    {
        private readonly Guid _userId;
        private readonly IMapper _mapper;

        public InvoiceService( Guid userId, IMapper mapper)
        {
            _userId = userId;
            _mapper = mapper;
        }

        public bool CreateInvoice(InvoiceCreate model)
        {
            var entity = new Invoice()
            {
                OwnerId = _userId,
                CompanyName = model.CompanyName,
                CompanyAddress = model.CompanyAddress,
                BillName = model.BillName,
                BillAddress = model.BillAddress,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Invoices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InvoiceListItem> GetInvoices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Invoices.Where(e => e.OwnerId == _userId)
                    .Select(e => new InvoiceListItem
                    {
                        InvoiceId = e.InvoiceId,
                        CompanyName = e.CompanyName,
                        BillName = e.BillName,
                        CreatedUtc = e.CreatedUtc
                    });

                return query.ToArray();
            }
        }

        public InvoiceDetail GetInvoiceById(int invoiceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Invoices.Single(e => e.InvoiceId == invoiceId && e.OwnerId == _userId);
                return new InvoiceDetail
                {
                    InvoiceId = entity.InvoiceId,
                    CompanyName = entity.CompanyName,
                    CompanyAddress = entity.CompanyAddress,
                    BillName = entity.BillName,
                    BillAddress = entity.BillAddress,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
    }
}
