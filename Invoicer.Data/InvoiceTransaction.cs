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
        public Guid OwnerId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
    }
}
