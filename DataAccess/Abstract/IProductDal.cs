using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract 
{   //IProductDal: Product in Dal ını temsil eder
    // !!! interface in operasyonlari default olarak public tir ama kendisi public degildir..
    //ürüne ait özel operasyonlari buraya ekleriz
    public interface IProductDal :IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails(); 
    }
    //Code Refactoring : kod iyilesştirilmesi
}
