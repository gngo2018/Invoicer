using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models
{
    public class InvoiceListItem
    {
        [Display(Name="Invoice ID")]
        public int InvoiceId { get; set; }
        [Display(Name="Company Name")]
        public string CompanyName { get; set; }
        [Display(Name="Bill To")]
        public string BillName { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
