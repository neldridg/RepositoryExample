using Dapper;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class CatRepository : RepositoryBase<Cat>
    {
        public override void Delete(Cat cat)
        {
            var catSql = @"delete from Cats where Id = " + cat.Id + ";";
            _connection.Query(catSql, transaction: _transaction);
        }

        public override Cat GetById(int id)
        {
            return _connection.Query<Cat>("select * from Cats where Id = " + id + ";", transaction: _transaction).FirstOrDefault();
        }

        public override void Insert(Cat cat)
        {
            var catSql = @"insert into Cats VALUES (" +
                            cat.Id + ", '" + cat.Name + "', " + Convert.ToInt32(cat.ShortHair) + ");";
            _connection.Query(catSql, transaction: _transaction);
        }

        public override void Update(Cat cat)
        {
            var catSql = @"update Dogs set Name = '" + cat.Name + "' and ShortHair = " + Convert.ToInt32(cat.ShortHair) + " where Id = " + cat.Id + ";";
            _connection.Query(catSql, transaction: _transaction);
        }

        public IEnumerable<Cat> GetAll()
        {
            return _connection.Query<Cat>("select * from Cats", transaction: _transaction);
        }
    }
}
