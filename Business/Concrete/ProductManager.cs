using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstarct;
using DataAccess.Abstarct;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Work codes here
            //if-else etc. as result 
            return _productDal.GetAll();
        }
    }
}
