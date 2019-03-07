using Invoicer.Data;
using Invoicer.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Service
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            //Total Price Calculation
            var totalPrice = model.ProductPrice * model.Quantity;

            var entity = new Product()
            {
                OwnerId = _userId,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                Quantity = model.Quantity,
                TotalPrice = totalPrice
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Where(e => e.OwnerId == _userId)
                    .Select(e => new ProductListItem
                    {
                        ProductId = e.ProductId,
                        ProductName = e.ProductName,
                        ProductPrice = e.ProductPrice,
                        Quantity = e.Quantity,
                        TotalPrice = e.TotalPrice
                    });

                return query.ToArray();
            }
        }
    }
}
