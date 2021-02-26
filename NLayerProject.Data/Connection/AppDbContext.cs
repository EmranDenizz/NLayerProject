using Microsoft.EntityFrameworkCore; //DbContext kullanımı için gerekli kütüphane
using NLayerProject.Core;
using NLayerProject.Data.Configurations;
using NLayerProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Modellerim tablolara dönüşürken primary key alacak mı, uzunluğu ne kadar vs. bilgiler burada tanımlanır.
            //"ProductConfiguration" ve "CategoryConfiguration" sınıflarını oluşturmayıp modellerimizin tabloda ki düzenlemelerini burada ayarlayabilirdik.
            //modelBuilder.Entity<Product>().HasKey(x => x.Id); 
            //modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn(); şeklinde yapılablirdi.
            //Best Practices açısından bakınca oluşturduğumuz 2 sınıfı bu metot içine aşağıdaki gibi geçiririz.
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
