namespace _01.PawInc.Core
{
    using Factories;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PawManager
    {
        private Dictionary<string, Center> centers;

        public PawManager()
        {
            this.centers = new Dictionary<string, Center>();
        }

        public void RegisterCleansingCenter(string cleansingCenterName)
        {
            Center cleansingCenter = CenterFactory.CreateCenter("Cleansing", cleansingCenterName);
            this.centers[cleansingCenterName] = cleansingCenter;
        }

        public void RegisterAdoptionCenter(string adoptionCenterName)
        {
            Center adoptionCenter = CenterFactory.CreateCenter("Adoption", adoptionCenterName);
            this.centers[adoptionCenterName] = adoptionCenter;
        }

        public void RegisterCastrationCenter(string castrationCenterName)
        {
            Center castrationCenter = CenterFactory.CreateCenter("Castration", castrationCenterName);
            this.centers[castrationCenterName] = castrationCenter;
        }

        public void RegisterDog(string animalName, int age, int commandsOrIntelligence, string adoptionCenterName)
        {
            Animal dog = AnmalFactory.CreateAnimal("Dog", animalName, age, commandsOrIntelligence, adoptionCenterName);
            this.centers[adoptionCenterName].AddAnimal(dog);
        }

        public void RegisterCat(string animalName, int age, int commandsOrIntelligence, string adoptionCenterName)
        {
            Animal cat = AnmalFactory.CreateAnimal("Cat", animalName, age, commandsOrIntelligence, adoptionCenterName);
            this.centers[adoptionCenterName].AddAnimal(cat);
        }

        public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
        {
            List<Animal> dirtyAnimalsToMove = this.centers[adoptionCenterName].GetDirtyAnimals();

            foreach (Animal animal in dirtyAnimalsToMove)
            {
                this.centers[cleansingCenterName].AddAnimal(animal);
            }

            this.centers[adoptionCenterName].RemoveDirtyAnimals();
        }

        public void Cleanse(string cleansingCenterName)
        {
            foreach (Animal animal in this.centers[cleansingCenterName].StoredAnimals)
            {
                this.centers[cleansingCenterName].CleanseAnimal(animal);

                this.centers[animal.AdoptionCenterName].AddAnimal(animal);

                this.centers[cleansingCenterName].AddAnimalToSpecialList(animal);
            }

            this.centers[cleansingCenterName].RemoveAllAnimals();
        }

        public void SendForCastration(string adoptionCenterName, string castrationCenterName)
        {
            List<Animal> animalsToMoveForCastration = this.centers[adoptionCenterName].StoredAnimals.ToList();

            foreach (Animal animal in animalsToMoveForCastration)
            {
                this.centers[castrationCenterName].AddAnimal(animal);
            }

            this.centers[adoptionCenterName].RemoveAllAnimals();
        }

        public void Castrate(string castrationCenterName)
        {
            foreach (Animal animal in this.centers[castrationCenterName].StoredAnimals)
            {
                this.centers[animal.AdoptionCenterName].AddAnimal(animal);

                this.centers[castrationCenterName].AddAnimalToSpecialList(animal);
            }

            this.centers[castrationCenterName].RemoveAllAnimals();
        }

        public void Adopt(string adoptionCenterName)
        {
            foreach (Animal animal in this.centers[adoptionCenterName].StoredAnimals.Where(animal => animal.Status == true))
            {
                this.centers[adoptionCenterName].AddAnimalToSpecialList(animal);
            }

            this.centers[adoptionCenterName].RemoveAdoptedAnimals();
        }

        public string GetCastrationStatistics()
        {
            List<string> castratedAnimalsNames = new List<string>();
            foreach (KeyValuePair<string, Center> center in this.centers.Where(c => c.Value.Type == "Castration"))
            {
                castratedAnimalsNames.AddRange(center.Value.GetSpecialListAnimalsNames());
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Paw Inc. Regular Castration Statistics");
            sb.AppendLine($"Castration Centers: {this.centers.Count(c => c.Value.Type == "Castration")}");
            sb.AppendLine(castratedAnimalsNames.Count == 0
                ? $"Castrated Animals: None"
                : $"Castrated Animals: {string.Join(", ", castratedAnimalsNames.OrderBy(name => name))}");

            return sb.ToString().Trim();
        }

        public string GetPawIncStatistics()
        {
            List<string> adoptedAnimalsNames = new List<string>();
            foreach (KeyValuePair<string, Center> center in this.centers.Where(c => c.Value.Type == "Adoption"))
            {
                adoptedAnimalsNames.AddRange(center.Value.GetSpecialListAnimalsNames());
            }

            List<string> cleansedAnimalsNames = new List<string>();
            foreach (KeyValuePair<string, Center> center in this.centers.Where(c => c.Value.Type == "Cleansing"))
            {
                cleansedAnimalsNames.AddRange(center.Value.GetSpecialListAnimalsNames());
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Paw Incorporative Regular Statistics");
            sb.AppendLine($"Adoption Centers: {this.centers.Count(c => c.Value.Type == "Adoption")}");
            sb.AppendLine($"Cleansing Centers: {this.centers.Count(c => c.Value.Type == "Cleansing")}");
            sb.AppendLine(adoptedAnimalsNames.Count == 0
                ? $"Adopted Animals: None"
                : $"Adopted Animals: {string.Join(", ", adoptedAnimalsNames.OrderBy(name => name))}");
            sb.AppendLine(cleansedAnimalsNames.Count == 0
                ? $"Cleansed Animals: None"
                : $"Cleansed Animals: {string.Join(", ", cleansedAnimalsNames.OrderBy(name => name))}");
            sb.AppendLine($"Animals Awaiting Adoption: {this.centers.Where(c => c.Value.Type == "Adoption").Sum(c => c.Value.GetNumberOfWaitingAnimals())}");
            sb.AppendLine($"Animals Awaiting Cleansing: {this.centers.Where(c => c.Value.Type == "Cleansing").Sum(c => c.Value.GetNumberOfWaitingAnimals())}");

            return sb.ToString().Trim();
        }
    }
}