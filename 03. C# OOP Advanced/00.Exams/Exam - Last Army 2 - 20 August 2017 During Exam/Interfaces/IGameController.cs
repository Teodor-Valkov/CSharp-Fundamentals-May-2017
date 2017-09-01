using System.Collections.Generic;

public interface IGameController
{
    void InterpretCommand(IList<string> tokens, IWriter writer);
}