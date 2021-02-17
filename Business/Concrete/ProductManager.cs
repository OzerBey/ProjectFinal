using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes
            //validation eklenecek nesnenin yapısı ile ilgili olması
            //business codes

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); // return bool value and message 
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new Result(true, "Product is added"); // return bool value and message 

        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new Result(true, "Product is added"); // return bool value and message 

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Work codes here
            //if-else etc. as result 

            if (DateTime.Now.Hour == 1) //saat 22.00 dan 23 e kadar bakımda 
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintananceTime);//MaintananceTime :Bakım zamanı
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {//SuccesDataResult içinde Product var ve onu constructor una (parantez içini) yolluyoruz aşagıda
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}