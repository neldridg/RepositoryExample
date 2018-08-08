using Repository.Repositories;
using System;

namespace RepositoryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cats = new CatRepository();
            var dogs = new DogRepository();

            dogs.CreateDatabase();
            cats.CreateDatabase();


            dogs.Insert(new Repository.Models.Dog
            {
                Breed = @"German Shepherd",
                Id = 3,
                Name = @"Good boy"
            });

            cats.Insert(new Repository.Models.Cat
            {
                Id = 3,
                Name = @"Lionel",
                ShortHair = false
            });

            var allCats = cats.GetAll();
            var allDogs = dogs.GetAll();

            Console.WriteLine("Dogs: ");
            foreach (var dog in allDogs)
            {
                Console.WriteLine(dog);
            }
            Console.WriteLine("Cats: ");
            foreach(var cat in allCats)
            {
                Console.WriteLine(cat);
            }
            dogs.Commit();
            Console.ReadKey();
        }


    }
}
