using AccountTransaction.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EntityFramework.BulkInsert.Extensions;

namespace AccountTransaction.DAL
{

    public class TransactionContext : DbContext,ITransactionDb
    {
        public TransactionContext()
            : base("name=LocalDBConnection")
        {


        }
        public DbSet<Transaction> Transactions { get; set; }

        IQueryable<T> ITransactionDb.Query<T>()
        {
            return Set<T>();
        }

        void ITransactionDb.Add<T>(T entity)
        {
            var options = new BulkInsertOptions
            {
                EnableStreaming = true,
            };

            try
            {
                var records = entity as IEnumerable<Transaction>;
                this.BulkInsert(records, options);
            }

            catch(Exception)
            {
                throw new Exception("Error while inserting record to Db");
            }
         
        }
      

        void ITransactionDb.Update<T>(T entity)
        {
            //Entry(entity).State = System.Data.EntityState.Modified;
        }

        void ITransactionDb.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void ITransactionDb.SaveChanges()
        {
            SaveChanges();
        }
   

    }
}