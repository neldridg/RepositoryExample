namespace Repository.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Breed;
        }
    }
}
