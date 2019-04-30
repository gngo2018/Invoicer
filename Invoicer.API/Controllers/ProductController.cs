using Invoicer.Models.Product;
using Invoicer.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Invoicer.API.Controllers
{
    //[Authorize]
    [EnableCorsAttribute("*", "*", "*")]
    public class ProductController : ApiController
    {
        //GET All Productss
        public IHttpActionResult Get()
        {
            ProductService svc = CreateProductService();
            var products = svc.GetProducts();
            return Ok(products);
        }
        //GET Product by Id
        public IHttpActionResult GetProductById(int id)
        {
            ProductService svc = CreateProductService();
            var products = svc.GetProductById(id);

            return Ok(products);
        }
        //POST Product Create
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateProductService();

            if (!svc.CreateProduct(product))
                return InternalServerError();

            return Ok("201");
        }
        //PUT Product Update
        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateProductService();

            if (!svc.UpdateProduct(product))
                return InternalServerError();

            return Ok("207");
        }
        //DELETE Product Delete
        public IHttpActionResult DeleteProduct(int id)
        {
            var svc = CreateProductService();

            if (!svc.DeleteProduct(id))
                return InternalServerError();

            return Ok("202");
        }
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);

            return productService;
        }
    }
}
