using App.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //program.cs içinden kurtarmak için bu extension kodu yazdık
            //efcore configuration

            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                }); //ünlemi compiler için koyuyoruz, bu datanın olduğunu belirtmek için
            });

            //Burada IProductRepository'i gördüğün zaman ProductRepository'den nesne örneği üreteceksin diyor
            //Yaşam döngüsü scoped request response a döndüğü anda ProductRepository bu nesnenin de response olması lazım
            //çünkü bu nesnelerde DbContext'ler var (DbContext'in kendisi Scoped)
            //veritabanı varsa o business logic içerisinde mutlaka scoped olmalıdır
            //Repository'ler singloten olmaz ya da Transient olmaz fakat efCore için geçerli bu
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); //eğer IGenericRepository bu birden fazla generic alsaydı
                                                                                          //ortaya <,> bu şekilde bir virgül koyacaktık

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services; 

        }
    }
}
