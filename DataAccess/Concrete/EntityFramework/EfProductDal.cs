using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{//Dal : Data access layer : veri erisim katmani
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //ürünler ile category leri join yap
                var result = from p in context.Products
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId //join yap bu şarta göre 
                             select new ProductDetailDto()
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             }; //sonucu bu kolonlara uydurarak ver demektir bu ifade
                return result.ToList();
            }


            //join process with Linq

        }
    }
}
