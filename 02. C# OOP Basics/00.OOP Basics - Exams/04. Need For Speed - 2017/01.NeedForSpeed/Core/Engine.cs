using System;

public class Engine
{
    private CarManager carManager;
    private bool isRunning;

    public Engine()
    {
        this.carManager = new CarManager();
        this.isRunning = true;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = this.ReadInput();

            if (input == Constants.InputEndCommand)
            {
                this.isRunning = false;
                continue;
            }

            string[] inputArgs = this.ParseInput(input);

            this.CommandInterpretator(inputArgs);
        }
    }

    private void CommandInterpretator(string[] inputArgs)
    {
        string command = inputArgs[0];

        switch (command)
        {
            case "register":
                int id = int.Parse(inputArgs[1]);
                string carType = inputArgs[2];
                string brand = inputArgs[3];
                string model = inputArgs[4];
                int yearOfProduction = int.Parse(inputArgs[5]);
                int horsepower = int.Parse(inputArgs[6]);
                int acceleration = int.Parse(inputArgs[7]);
                int suspension = int.Parse(inputArgs[8]);
                int durability = int.Parse(inputArgs[9]);

                this.carManager.Register(id, carType, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;

            case "check":
                int checkId = int.Parse(inputArgs[1]);
                string car = this.carManager.Check(checkId);

                this.OutputWriter(car);
                break;

            case "open":
                int openId = int.Parse(inputArgs[1]);
                string openType = inputArgs[2];
                int length = int.Parse(inputArgs[3]);
                string route = inputArgs[4];
                int prizePool = int.Parse(inputArgs[5]);

                switch (inputArgs.Length)
                {
                    case 6:
                        this.carManager.Open(openId, openType, length, route, prizePool);
                        break;

                    case 7:
                        int specialRaceParameter = int.Parse(inputArgs[6]);
                        this.carManager.Open(openId, openType, length, route, prizePool, specialRaceParameter);
                        break;
                }

                break;

            case "participate":
                int carId = int.Parse(inputArgs[1]);
                int raceId = int.Parse(inputArgs[2]);

                this.carManager.Participate(carId, raceId);
                break;

            case "start":
                int startId = int.Parse(inputArgs[1]);
                string winners = this.carManager.Start(startId);

                this.OutputWriter(winners);
                break;

            case "park":
                int parkId = int.Parse(inputArgs[1]);

                this.carManager.Park(parkId);
                break;

            case "unpark":
                int unparkId = int.Parse(inputArgs[1]);

                this.carManager.Unpark(unparkId);
                break;

            case "tune":
                int tuneIndex = int.Parse(inputArgs[1]);
                string addOn = inputArgs[2];

                for (int i = 3; i < inputArgs.Length; i++)
                {
                    addOn += " " + inputArgs[i];
                }

                this.carManager.Tune(tuneIndex, addOn);
                break;
        }
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }

    private string[] ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private void OutputWriter(string ouput)
    {
        Console.WriteLine(ouput);
    }
}