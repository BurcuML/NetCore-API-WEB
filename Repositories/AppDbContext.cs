using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class AppDbContext(DbContextOptions options) : DbContext(options) //miras aldığımız sınıfın constructoer'ına bu options ı gönderiyoruz
                                                                             //bu options'ı API tarafındaki appsetings de tanımladığımız connection string'i buraya geçeceğiz
                                                                             //o yüzden bu şekilde hazırlık yapıyoruz
    {

        //bu şekilde de yazzabiliz ya da yukarıdaki gibi de yazabiliriz
        //constructor
        /* public AppDbContext(DbContextOptions options) : base(options) //birden fazla dbcontext olsaydı "DbContextOptions<AppDbContext> options" bu şekilde verebilirdik
         {
         }*/


        //Tablo
        public DbSet<Product> Products { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //burada, bu repository içersindeki IEntityTypeConfiguration'ı implement etmiş olan tüm sınıfları al diyoruz

            base.OnModelCreating(modelBuilder);
        }
    }
}