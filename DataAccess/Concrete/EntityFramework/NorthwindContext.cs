using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{//contex: Db tabloları ile proje classlarını bağlamak (iliskilendirmek)
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //projem hangi veri tabanı ile ilişkili oldugunu belirtecegimiz yerdir
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        //benim veri classlarımı veri tabanındaki isimlere eşitledigimiz properties
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; } // Orderi Orders ile iliskilendir
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        //public DbSet<Personel> Personels { get; set; } // veri tabanında buradaki Personels diye bi veri olamdfıgı için tanımaz o yüzden OnModelCreating methodunu override edip tanıtırız 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //fluent mapping
        //    //modelBuilder.HasDefaultSchema("admin");
        //    modelBuilder.Entity<Personel>().ToTable("Employees", "dbo"); // Bizim Personel isimli classımız Employee isimli tablodur diye belirtmiş oluyoruz
        //    //schema:"dbo" dafault olarak dpo ise vermemize gerek yoktur
        //    modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");
        //    modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
        //    modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");



        //}
    }
}
