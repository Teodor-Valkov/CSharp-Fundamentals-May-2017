namespace _01.PawInc.Models.Centers
{
    using System.Collections.Generic;
    using System.Linq;

    public class CleansingCenter : Center
    {
        private List<Animal> cleansedAnimals;

        public CleansingCenter(string name, string type)
            : base(name, type)
        {
            this.cleansedAnimals = new List<Animal>();
        }

        public override void AddAnimalToSpecialList(Animal animal)
        {
            this.cleansedAnimals.Add(animal);
        }

        public override int GetNumberOfWaitingAnimals()
        {
            return this.StoredAnimals.Count(animal => animal.Status == false);
        }

        public override List<string> GetSpecialListAnimalsNames()
        {
            return this.cleansedAnimals.Select(animal => animal.Name).ToList();
        }
    }
}