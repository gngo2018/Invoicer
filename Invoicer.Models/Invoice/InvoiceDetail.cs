using Invoicer.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models.Invoice
{
    public class InvoiceDetail
    {
        //Note: Can't store a list in DB, but can showcase it
        //Note: Grand Total should be added here as well cause getting Invoice + Product by InvoiceId
        public int InvoiceId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string BillName { get; set; }
        public string BillAddress { get; set; }
        public decimal GrandTotal { get; set; }
        public List<ProductListItem> ProductList { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
