using System.Collections.Generic;
using System.Linq;

public class PetRepository
{
    private IList<Pet> pets;

    public PetRepository()
    {
        this.pets = new List<Pet>();
    }

    public void AddPet(Pet pet)
    {
        this.pets.Add(pet);
    }

    public void RemovePet(Pet pet)
    {
        this.pets.Remove(pet);
    }

    public Pet FindPetByName(string petName)
    {
        return this.pets.FirstOrDefault(pet => pet.Name == petName);
    }
}