using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models.InvoiceTransaction
{
    public class InvoiceTransactionListItem
    {
        public int InvoiceTransactionId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
