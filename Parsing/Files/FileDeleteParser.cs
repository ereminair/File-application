using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Files;

public class FileDeleteParser : Parser
{
    public override ICommand? Handle(string command)
    {
        string[] path = command.Split(' ');

        if (path[0] != "file" || path[1] != "delete")
        {
            return Next?.Handle(command);
        }

        if (path.Length != 3)
        {
            return new UnknownCommand();
        }

        return new FileDeleteCommand(path[2]);
    }
}