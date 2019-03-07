using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models.InvoiceTransaction
{
    public class InvoiceTransactionEdit
    {
        public int InvoiceTransactionId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
