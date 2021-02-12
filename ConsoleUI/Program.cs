using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
           // productManager.Add(new Product() { ProductId = 1, CategoryId = 2, UnitPrice = 135, ProductName = "ELma", UnitsInStock = 3 });
           Console.WriteLine(productManager.GetById(1).ProductName);
           foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductId + " : " + product.ProductName);
            }
            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            //productManager.Add(new Product(){ProductId = 1,CategoryId = 2,UnitPrice = 135,ProductName = "ELma",UnitsInStock = 3});
        }
    }
}
