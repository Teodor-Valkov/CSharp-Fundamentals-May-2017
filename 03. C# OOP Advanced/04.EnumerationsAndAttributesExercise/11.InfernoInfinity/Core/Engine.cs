using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private WeaponManager weaponManager;
    private bool isRunning;

    public Engine()
    {
        this.weaponManager = new WeaponManager();
        this.isRunning = true;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = InputReader.Read();

            List<string> inputArgs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            this.CommandDispatcher(inputArgs);
        }
    }

    private void CommandDispatcher(List<string> inputArgs)
    {
        string command = inputArgs[0];
        inputArgs.RemoveAt(0);

        string output = string.Empty;

        switch (command)
        {
            case "Create":
                this.weaponManager.CreateWeapon(inputArgs);
                break;

            case "Add":
                this.weaponManager.AddSocket(inputArgs);
                break;

            case "Remove":
                this.weaponManager.RemoveSocket(inputArgs);
                break;

            case "Print":
                output = this.weaponManager.GetWeaponToPrint(inputArgs);
                OutputWriter.Write(output);
                break;

            case "END":
                this.isRunning = false;
                break;
        }
    }
}