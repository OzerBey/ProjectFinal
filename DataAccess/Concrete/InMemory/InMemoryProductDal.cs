using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;  //name of reference type

        public InMemoryProductDal()
        {
            _products = new List<Product>()//occur a instance in Product
            {
                //Oracle,Sql Server, Postgres, MongoDb gibi veritabanlarından geliyormus gibi simüle ettik
                new Product(){ProductId = 1,CategoryId = 1,ProductName ="Table",UnitPrice = 15,UnitInStock = 15},
                new Product(){ProductId = 2,CategoryId = 1,ProductName ="Camera",UnitPrice = 500,UnitInStock = 3},
                new Product(){ProductId = 3,CategoryId = 2,ProductName ="Phone",UnitPrice = 1500,UnitInStock = 2},
                new Product(){ProductId = 4,CategoryId = 2,ProductName ="Keyboard",UnitPrice = 150,UnitInStock = 65},
                new Product(){ProductId = 5,CategoryId = 2,ProductName ="Mouse",UnitPrice = 85,UnitInStock = 1},

            };
        }
        public List<Product> GetAll()
        {
            return _products; //return the database 
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {//gönderilen ürün id'ine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //her p için durum kontrolü yapar !! foreach gibi çalışır
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }

        public void Delete(Product product)
        {
            //=> :Lambda ... SingleOrDefault(p=>); kodu foreach görevi gibi çalışır
            //LINQ : Language Integrated Query
            /*
            Product productToDelete = null; //temp reference assign
            /*  foreach (var p in _products)//without using with LINQ
              {
                  if (product.ProductId == p.ProductId)
                  {
                      productToDelete = p;
                  }
              }*/
            //SingleOrDefault : tek bir deger döndürür.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //her p için durum kontrolü yapar !! foreach gibi çalışır
            _products.Remove(productToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // where koşulu içindeki kurala uyanları yeni bir liste haline getirip onu liste şeklinde döndürür
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
