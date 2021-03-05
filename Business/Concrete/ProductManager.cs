using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
        private ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                   CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); // return bool value and message 

        }

        public IResult Delete(Product product)
        {
            //business codes
            //validation eklenecek nesnenin yapısı ile ilgili olması
            //business codes

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


        [CacheAspect] //key,value
        public IDataResult<List<Product>> GetAll()
        {
            //Work codes here
            //if-else etc. as result 

            if (DateTime.Now.Hour == 23) //saat 23.00 dan 24.00 a kadar bakımda 
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

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //bir ürün eklemek istenilen ürünün kategorisinde max 10 ürün olabilir

            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count; //select count(*) from products where categoryId=1
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //ayni isimde isim eklenemez
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//any var mı demektir   any: true or false
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();

        }

        private IResult CheckIfCategoryLimitExceded()
        {
            //Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez kuralı
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
    }
}