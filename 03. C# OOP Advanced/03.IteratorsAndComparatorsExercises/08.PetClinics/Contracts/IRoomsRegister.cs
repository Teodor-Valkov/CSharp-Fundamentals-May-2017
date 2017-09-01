using System.Collections.Generic;

public interface IRoomsRegister : IEnumerable<int>
{
    Pet this[int index] { get; }

    int CenterRoom { get; }

    IList<Pet> Rooms { get; }

    void AddPetToRoom(int roomIndex, Pet pet);

    void RemovePetFromRoom(int roomIndex);
}