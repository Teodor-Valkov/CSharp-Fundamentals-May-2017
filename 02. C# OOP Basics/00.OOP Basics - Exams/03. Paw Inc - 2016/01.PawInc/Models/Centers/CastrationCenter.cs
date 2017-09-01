namespace _01.PawInc.Models.Centers
{
    using System.Collections.Generic;
    using System.Linq;

    public class CastrationCenter : Center
    {
        private List<Animal> castratedAnimals;

        public CastrationCenter(string name, string type)
            : base(name, type)
        {
            this.castratedAnimals = new List<Animal>();
        }

        public override void AddAnimalToSpecialList(Animal animal)
        {
            this.castratedAnimals.Add(animal);
        }

        public override List<string> GetSpecialListAnimalsNames()
        {
            return this.castratedAnimals.Select(animal => animal.Name).ToList();
        }
    }
}