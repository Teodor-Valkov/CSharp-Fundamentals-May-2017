namespace _01.PawInc.Models.Centers
{
    using System.Collections.Generic;
    using System.Linq;

    public class AdoptionCenter : Center
    {
        private List<Animal> adoptedAnimals;

        public AdoptionCenter(string name, string type)
            : base(name, type)
        {
            this.adoptedAnimals = new List<Animal>();
        }

        public override void AddAnimalToSpecialList(Animal animal)
        {
            this.adoptedAnimals.Add(animal);
        }

        public override int GetNumberOfWaitingAnimals()
        {
            return this.StoredAnimals.Count(animal => animal.Status == true);
        }

        public override List<string> GetSpecialListAnimalsNames()
        {
            return this.adoptedAnimals.Select(animal => animal.Name).ToList();
        }
    }
}