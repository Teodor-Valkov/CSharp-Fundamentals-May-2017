using System.Collections;
using System.Collections.Generic;

public class RoomsRegister : IEnumerable<int>, IRoomsRegister
{
    public RoomsRegister(int numberOfRooms)
    {
        this.CenterRoom = numberOfRooms / 2;
        this.Rooms = new List<Pet>(new Pet[numberOfRooms]);
    }

    public int CenterRoom { get; private set; }

    public IList<Pet> Rooms { get; private set; }

    public Pet this[int index]
    {
        get { return this.Rooms[index]; }
        private set { this.Rooms[index] = value; }
    }

    public void AddPetToRoom(int roomIndex, Pet pet)
    {
        this.Rooms[roomIndex] = pet;
    }

    public void RemovePetFromRoom(int roomIndex)
    {
        this.Rooms[roomIndex] = null;
    }

    public IEnumerator<int> GetEnumerator()
    {
        int step = 1;

        yield return this.CenterRoom;

        while (step <= this.CenterRoom)
        {
            yield return this.CenterRoom - step;

            yield return this.CenterRoom + step++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}