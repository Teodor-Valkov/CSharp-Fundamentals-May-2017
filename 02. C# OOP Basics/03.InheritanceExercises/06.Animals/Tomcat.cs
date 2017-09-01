using System;

public class Tomcat : Cat
{
    public Tomcat(string name, int age)
        : base(name, age, "Male")
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Give me one million b***h");
    }
}