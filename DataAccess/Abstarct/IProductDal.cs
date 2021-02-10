using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstarct
{   //IProductDal: Product in Dal ını temsil eder
    // !!! interface in operasyonlari default olarak public tir ama kendisi public degildir..
    public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);

    }
}
