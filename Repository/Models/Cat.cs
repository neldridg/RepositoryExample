namespace Repository.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShortHair { get; set; }


        public override string ToString()
        {
            return Id + " " + Name + " " + ShortHair;
        }
    }
}
