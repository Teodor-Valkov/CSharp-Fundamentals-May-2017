using System.Collections.Generic;
using System.Linq;

public class ClinicRepository
{
    private IList<Clinic> clinics;

    public ClinicRepository()
    {
        this.clinics = new List<Clinic>();
    }

    public void AddClinic(Clinic clinic)
    {
        this.clinics.Add(clinic);
    }

    public bool HasEmptyRooms(Clinic clinic)
    {
        return clinic.OccupiedRooms < clinic.NumberOfRooms;
    }

    public Clinic FindClinicByName(string clinicName)
    {
        return this.clinics.FirstOrDefault(clinic => clinic.Name == clinicName);
    }

    public bool TryAddPet(Clinic clinic, Pet pet)
    {
        foreach (int roomIndex in clinic.RoomRegister)
        {
            if (clinic.RoomRegister[roomIndex] == null)
            {
                clinic.RoomRegister.AddPetToRoom(roomIndex, pet);
                clinic.OccupyRoom();
                return true;
            }
        }

        return false;
    }

    public bool TryReleasePet(Clinic clinic)
    {
        int centralRoomIndex = clinic.NumberOfRooms / 2;

        for (int i = 0; i < clinic.NumberOfRooms; i++)
        {
            int roomIndex = (centralRoomIndex + i) % clinic.NumberOfRooms;

            if (clinic.RoomRegister[roomIndex] != null)
            {
                clinic.RoomRegister.RemovePetFromRoom(roomIndex);
                return true;
            }
        }

        return false;
    }
}