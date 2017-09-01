namespace _01.PawInc.Models.Animals
{
    public class Dog : Animal
    {
        private int commands;

        public Dog(string name, int age, int commands, string centerName)
            : base(name, age, centerName)
        {
            this.commands = commands;
        }
    }
}