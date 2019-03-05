using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models
{
    public class InvoiceCreate
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string BillName { get; set; }
        public string BillAddress { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
