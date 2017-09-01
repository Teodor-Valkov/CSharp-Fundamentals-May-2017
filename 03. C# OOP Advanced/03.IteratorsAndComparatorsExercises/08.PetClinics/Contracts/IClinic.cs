public interface IClinic
{
    string Name { get; }

    int NumberOfRooms { get; }

    RoomsRegister RoomRegister { get; }
}