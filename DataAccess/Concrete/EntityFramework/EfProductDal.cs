using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        //NuGet: DataAccess icinde entityframework kodu yazabilecegimiz anlamına gelir 
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)//filtre verebilir ama vermeyedebilir default u null oldugu icin
        {
            using (NorthwindContext context = new NorthwindContext()) //context nesnesi bellek için pahalı bir nesnedir o yüzden using kullanırız using kullanmak garbage colleector ü beklemeden bu using bittikten sonra bellekten atılır
            {
                //return context.Products.ToList();
                //ternary operatörü
                return filter == null  //is filter equals null
                   ? context.Set<Product>().ToList() //if yes 
                    : context.Set<Product>().Where(filter).ToList(); // if no return filtered objects
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // return a product 
            }
        }

        public Product GetById(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);//FirstOrDefault veya SingleOrDefault kullanbiliriz singleOrDefault a birden fazla deger dönerse sistem hata verir
                //ama FirstOrDefault kullanırsak birden fazla aynı deger varsa ilkini bize döndürür
            }
        }

        public void Add(Product entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (NorthwindContext context = new NorthwindContext()) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {

                var addedEntity = context.Entry(entity);//git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                addedEntity.State = EntityState.Added; //eklenecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges();//son değişiklik kaydı
            }
        }

        public void Update(Product entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (NorthwindContext context = new NorthwindContext()) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {
                var updatedEntity = context.Entry(entity);//git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                updatedEntity.State = EntityState.Modified; //güncellenecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges();//son değişiklik kaydı
            }
        }

        public void Delete(Product entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (NorthwindContext context = new NorthwindContext()) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {
                var deletedEntity = context.Entry(entity);//git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                deletedEntity.State = EntityState.Deleted; //silinecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges();//son değişiklik kaydı
            }
        }
    }
}
