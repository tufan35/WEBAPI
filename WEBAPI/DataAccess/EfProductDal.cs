using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Entities;
using WEBAPI.Models;

namespace WEBAPI.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product, Context>, IProductDal
    {
        public List<ProductModel> GetProductsWithDetails()
        {
            using (Context db = new Context())
            {

                var result = from p in db.Products join c in db.Categories on p.CategoryId equals c.CategoryId select new ProductModel { ProductId =p.ProductId , ProductName = p.ProductName, CategoryName =c.CategoryName , UnitPrice = p.UnitPrice} ;
                return result.ToList();
            
            }
        }
    }
}
