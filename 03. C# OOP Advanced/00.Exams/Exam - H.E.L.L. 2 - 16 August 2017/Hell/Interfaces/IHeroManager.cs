using System.Collections.Generic;

public interface IHeroManager
{
    IExecutable InterpretCommand(List<string> tokens);
}