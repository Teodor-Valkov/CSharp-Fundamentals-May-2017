using System;
using System.Collections.Generic;

public class CommandDispatcher
{
    private PetRepository petRepository;
    private ClinicRepository clinicRepository;

    public CommandDispatcher()
    {
        this.petRepository = new PetRepository();
        this.clinicRepository = new ClinicRepository();
    }

    public void CreatePet(List<string> inputArgs)
    {
        try
        {
            Pet pet = PetFactory.CreatePet(inputArgs);
            this.petRepository.AddPet(pet);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void CreateClinic(List<string> inputArgs)
    {
        try
        {
            Clinic clinic = ClinicFactory.CreateClinic(inputArgs);
            this.clinicRepository.AddClinic(clinic);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public bool Add(List<string> inputArgs)
    {
        string petName = inputArgs[0];
        string clinicName = inputArgs[1];

        Pet pet = this.petRepository.FindPetByName(petName);
        Clinic clinic = this.clinicRepository.FindClinicByName(clinicName);

        if (this.clinicRepository.TryAddPet(clinic, pet))
        {
            this.petRepository.RemovePet(pet);
            return true;
        }

        return false;
    }

    public bool Release(List<string> inputArgs)
    {
        string clinicName = inputArgs[0];

        Clinic clinic = this.clinicRepository.FindClinicByName(clinicName);

        return this.clinicRepository.TryReleasePet(clinic);
    }

    public bool HasEmptyRooms(List<string> inputArgs)
    {
        string clinicName = inputArgs[0];

        Clinic clinic = this.clinicRepository.FindClinicByName(clinicName);

        return this.clinicRepository.HasEmptyRooms(clinic);
    }

    public string PrintRoom(List<string> inputArgs)
    {
        string clinicName = inputArgs[0];
        int clinicRoom = int.Parse(inputArgs[1]) - 1;

        Clinic clinic = this.clinicRepository.FindClinicByName(clinicName);

        return clinic.Print(clinicRoom);
    }

    public string PrintAll(List<string> inputArgs)
    {
        string clinicName = inputArgs[0];

        Clinic clinic = this.clinicRepository.FindClinicByName(clinicName);

        return clinic.Print();
    }
}