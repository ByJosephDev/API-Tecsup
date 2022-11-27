using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        public List<Product> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Products.Where(x => x.IsEnabled == true).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Products.Find(id);
            }
        }


        public void InsertOrUpdate(Product product)
        {
            using (var context = new ExampleContext())
            {
                
                if (product.ProductID == 0)
                {
                    product.IsEnabled = true;
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    Product productUpdate = context.Products.Find(product.ProductID);
                    context.Entry(productUpdate).State = EntityState.Modified;
                    productUpdate.IsEnabled = product.IsEnabled;
                    productUpdate.Name = product.Name;
                    productUpdate.Price= product.Price;
                    productUpdate.Description = product.Description;
                    productUpdate.IGV = product.IGV;
                    productUpdate.ExpiredDate = product.ExpiredDate;
                    productUpdate.CreatedDate = product.CreatedDate;
                    context.SaveChanges();

                }
            }
        }

        public void Delete(int id)
        {

            using (var context = new ExampleContext())
            {

                    Product productUpdate = context.Products.Find(id);
                    context.Entry(productUpdate).State = EntityState.Modified;
                    productUpdate.IsEnabled = false;
                    context.SaveChanges();
            }

        }

    }
}
