using Dapper;
using Repository.Models;
using System.Linq;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class DogRepository : RepositoryBase<Dog>
    {
        public override void Delete(Dog dog) 
        {
            var dogSql = @"delete from Dogs where Id = " + dog.Id +";";
            _connection.Query(dogSql, transaction: _transaction);
        }

        public override Dog GetById(int id)
        {
            return _connection.Query<Dog>("select * from Dogs where Id = " + id + ";", transaction: _transaction).FirstOrDefault();
        }

        public override void Insert(Dog dog)
        {
            var dogSql = @"insert into Dogs VALUES (" +
                            dog.Id + ", '" + dog.Name + "', '" + dog.Breed + "');";
            _connection.Query(dogSql, transaction: _transaction);
        }

        public override void Update(Dog dog)
        {
            var dogSql = @"update Dogs set Name = '" + dog.Name + "' and Breed = '" + dog.Breed + "' where Id = " + dog.Id + ";";
            _connection.Query(dogSql, transaction: _transaction);
        }

        public IEnumerable<Dog> GetAll()
        {
            return _connection.Query<Dog>("select * from Dogs", transaction: _transaction);
        }
    }
}
