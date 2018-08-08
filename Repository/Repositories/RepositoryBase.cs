using Repository.Interfaces;
using System;
using System.Data.SQLite;
using Dapper;

namespace Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>, IDisposable
    {
        /// <summary>
        /// Just using a SQLite database for the purposes of this demo.
        /// </summary>
        protected SQLiteConnection _connection = new SQLiteConnection("Data Source=:memory:");
        protected SQLiteTransaction _transaction;
        private bool _disposed;
        /// <summary>
        /// Opens a connection for each object created.
        /// </summary>
        protected internal RepositoryBase()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public abstract void Delete(T entity);
        public abstract T GetById(int id);
        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        /// <summary>
        /// Cleans up after a transaction is complete.
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }
        }
        public void Dispose()
        {
            Disposable(true);
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        private void Disposable(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                _disposed = true;
            }
        }

        public void CreateDatabase()
        {
            const string sqlCmd = @"create table Dogs (Id int PRIMARY KEY, Name varchar(50), Breed varchar(50)); "
                            + "create table Cats (Id int PRIMARY KEY, Name varchar(50), ShortHair bit); "
                            + "insert into Dogs VALUES (1, 'Fido', 'Chocolate Lab');"
                            + "insert into Dogs VALUES (2, 'Spot', 'Dalmation');"
                            + "insert into Cats VALUES (1, 'Mittens', 1);"
                            + "insert into Cats VALUES (2, 'Mr. Floof', 0);";
            _connection.Query(sqlCmd);
        }

    }
}
