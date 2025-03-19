using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Files;

public class FileMoveParser : Parser
{
    public override ICommand? Handle(string command)
    {
        string[] path = command.Split(' ');

        if (path[0] != "file" || path[1] != "move")
        {
            return Next?.Handle(command);
        }

        if (path.Length != 4)
        {
            return new UnknownCommand();
        }

        return new FileMoveCommand(path[2], path[3]);
    }
}