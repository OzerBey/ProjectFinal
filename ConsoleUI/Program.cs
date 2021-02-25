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
            // CategoryTest();
            // GetAll(productManager);
            ProductTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        //private static void EfProductDalUsing(PersonelManager personelManager)
        //{
        //    foreach (var personel in personelManager.GetAll())
        //    {
        //        Console.WriteLine(" {0} / {1} / {2}", personel.Id, personel.Name, personel.Surname);
        //    }
        //}
        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " => " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            // productManager.Add(new Product() { ProductId = 1, CategoryId = 2, UnitPrice = 135, ProductName = "ELma", UnitsInStock = 3 });
            // Console.WriteLine(productManager.GetById(1).QuantityPerUnit);
        }
        private static void GetAll(ProductManager productManager)
        {
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductId + " : " + product.ProductName);
            }
        }
    }
}
