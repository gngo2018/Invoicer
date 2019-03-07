using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models.InvoiceTransaction
{
    //TODO: Look at red badge project PC Detail
    public class InvoiceTransactionDetail
    {
        public int InvoiceTransactionId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
