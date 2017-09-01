using _06.BirthdayCelebration.Contracts;

namespace _06.BirthdayCelebration.Models
{
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