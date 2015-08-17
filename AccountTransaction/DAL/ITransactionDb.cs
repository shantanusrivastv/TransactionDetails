using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTransaction.DAL
{
    public interface ITransactionDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class , IEnumerable<AccountTransaction.Models.Transaction>;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }
}
