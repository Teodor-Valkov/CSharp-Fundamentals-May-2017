namespace _07.FoodShortage.Models
{
    using Contracts;

    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }

        public string Birthday { get; private set; }
    }
}