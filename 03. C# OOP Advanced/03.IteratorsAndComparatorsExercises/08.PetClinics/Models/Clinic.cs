using System;
using System.Text;

public class Clinic : IClinic
{
    private int numberOfRooms;

    public Clinic(string name, int numberOfRooms)
    {
        this.Name = name;
        this.NumberOfRooms = numberOfRooms;
        this.RoomRegister = new RoomsRegister(numberOfRooms);
    }

    public string Name { get; private set; }

    public int NumberOfRooms
    {
        get
        {
            return this.numberOfRooms;
        }
        private set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.numberOfRooms = value;
        }
    }

    public RoomsRegister RoomRegister { get; private set; }

    public int OccupiedRooms { get; private set; }

    public void OccupyRoom()
    {
        this.OccupiedRooms++;
    }

    public string Print(int roomIndex)
    {
        return this.RoomRegister[roomIndex]?.ToString() ?? "Room empty";
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.NumberOfRooms; i++)
        {
            sb.AppendLine(this.Print(i));
        }

        return sb.ToString().TrimEnd();
    }
}