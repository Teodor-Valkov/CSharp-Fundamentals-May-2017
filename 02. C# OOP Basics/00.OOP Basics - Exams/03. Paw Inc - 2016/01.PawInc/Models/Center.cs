namespace _01.PawInc.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Center
    {
        private string name;
        private string type;
        private List<Animal> storedAnimals;

        protected Center(string name, string type)
        {
            this.name = name;
            this.type = type;
            this.storedAnimals = new List<Animal>();
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        public IReadOnlyList<Animal> StoredAnimals
        {
            get
            {
                return this.storedAnimals;
            }
        }

        public void AddAnimal(Animal animal)
        {
            this.storedAnimals.Add(animal);
        }

        public List<Animal> GetDirtyAnimals()
        {
            return this.storedAnimals.Where(animal => animal.Status == false).ToList();
        }

        public void RemoveAllAnimals()
        {
            this.storedAnimals.Clear();
        }

        public void RemoveDirtyAnimals()
        {
            this.storedAnimals.RemoveAll(animal => animal.Status == false);
        }

        public void RemoveAdoptedAnimals()
        {
            this.storedAnimals.RemoveAll(animal => animal.Status == true);
        }

        public void CleanseAnimal(Animal animal)
        {
            animal.Cleanse();
        }

        public virtual int GetNumberOfWaitingAnimals()
        {
            return 0;
        }

        public abstract void AddAnimalToSpecialList(Animal animal);

        public abstract List<string> GetSpecialListAnimalsNames();
    }
}