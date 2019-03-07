using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models.Product
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
