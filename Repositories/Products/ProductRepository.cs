using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Products
{
    //constructor'lar miras yoluyla gelmez, o yüzden bu class da constructor da aldığımız datayı(ProductRepository(AppDbContext context))
    //miras aldığımız sınıfın(GenericRepository<Product>(context)) constructor'ına gönderiyoruz 
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public Task<List<Product>> GetTopSellingProductAsync(int count)
        {
            return Context.Products.OrderByDescending(x => x.Price).Take(count).ToListAsync();
        }
    }
}
