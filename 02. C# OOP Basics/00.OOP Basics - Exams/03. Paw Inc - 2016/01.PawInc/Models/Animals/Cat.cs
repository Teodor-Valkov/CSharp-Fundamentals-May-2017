namespace _01.PawInc.Models.Animals
{
    public class Cat : Animal
    {
        private int intelligence;

        public Cat(string name, int age, int intelligence, string centerName)
            : base(name, age, centerName)
        {
            this.intelligence = intelligence;
        }
    }
}