using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {

        //before IDataResult
        //void Add(Product product); //we will use a IResult instead of void ..  
        //void Delete(Product product);
        //void Update(Product product);
        //Product GetById(int productId); //we will use a IDataResult instead of Product or List<Product>
        //List<Product> GetAll();
        //List<Product> GetAllByCategoryId(int id);
        //List<Product> GetByUnitPrice(decimal min, decimal max);
        //List<ProductDetailDto> GetProductDetails();

        //after IDataResult
        IResult Add(Product product); //we used a IResult instead of void ...
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

    }
}
