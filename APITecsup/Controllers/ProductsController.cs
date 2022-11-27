using APITecsup.Models.Request;
using APITecsup.Models.Response;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace APITecsup.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public List<ProductResponse> Get()
        {

            var service = new ProductService();
            var products = service.Get();

            //Convert Domaint to Response
            var response = products.Select(x => new ProductResponse
            {
                ProductID= x.ProductID,
                Name= x.Name,
                Description= x.Description,
                CreatedDate= x.CreatedDate,
                ExpiredDate= x.ExpiredDate,
                Price= x.Price,
                IGV = x.IGV,
                IsEnabled= x.IsEnabled,

            }).ToList();

            return response;
        }

        // GET: api/Products/5
        public ProductResponse Get(int id)
        {
                var service = new ProductService();
                var product = service.GetById(id);

                //Convert Domaint to Response
                var response = new ProductResponse
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    Description = product.Description,
                    CreatedDate = product.CreatedDate,
                    ExpiredDate = product.ExpiredDate,
                    Price = product.Price,
                    IGV = product.IGV,
                    IsEnabled = product.IsEnabled,

                };

                return response;
            
        }

        // POST: api/Products
        [HttpPost]
        public string Post(ProductRequest productR)
        {

            Product product = new Product();

            product.ProductID = productR.ProductID;
            product.Name = productR.Name;
            product.Description = productR.Description;
            product.Price = productR.Price;
            product.CreatedDate = productR.CreatedDate;
            product.ExpiredDate = productR.ExpiredDate;
            product.IsEnabled = productR.IsEnabled;
            product.IGV = Math.Round(productR.Price * 0.18, 2);
        
            var service = new ProductService();
            service.InsertOrUpdate(product);

            return "Producto enviado exitosamente";

        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        [HttpDelete]
        public string Delete(int id)
        {
            var service = new ProductService();
            service.Delete(id);
            return "Eliminado Exitoso";
        }
    }
}
