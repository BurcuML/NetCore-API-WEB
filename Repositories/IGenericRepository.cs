using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);//içine bir şart yazmak istersek bunu kullanabiliriz
        IQueryable<T> GetAll(); //bu methotta IQueryable dönmek isteriz çünkü service katmanında çağırdığımız zaman orderby yapmak isteyebiliriz
                                //direkt veritabanı orderby yapılabilmesi için IQueryable dönmemiz gerek

        ValueTask<T?> GetByIdAsync(int id); //ValueTask'lar Task'lardan daha hafiftir, Task referans tiptir, diğeri ise value type'dır
        ValueTask AddAsync(T entity);
        void Update(T entity); //asenkron metotları olmadığı için geriye void dönüyoruz, asenkronu daha sonra kullanacağız
        void Delete(T entity);
    }
}
