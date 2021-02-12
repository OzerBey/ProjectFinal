using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{//contex: Db tabloları ile proje classlarını bağlamak (iliskilendirmek)
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //projem hangi veri tabanı ile ilişkili oldugunu belirtecegimiz yerdir
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=true");
        }

        //benim veri classlarımı veri tabanındaki isimlere eşitledigimiz properties
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
