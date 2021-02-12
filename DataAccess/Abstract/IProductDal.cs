using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract 
{   //IProductDal: Product in Dal ını temsil eder
    // !!! interface in operasyonlari default olarak public tir ama kendisi public degildir..
    public interface IProductDal :IEntityRepository<Product>
    {


    }
}
