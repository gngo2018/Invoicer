using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Data
{
    public class InvoiceTransaction
    {
        public int InvoiceTransactionId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
