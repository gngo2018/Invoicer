using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models.InvoiceTransaction
{
    public class InvoiceTransactionCreate
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
