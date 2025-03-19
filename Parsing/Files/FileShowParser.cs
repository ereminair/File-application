using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;
using Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Files;

public class FileShowParser : Parser
{
    public override ICommand? Handle(string command)
    {
        string[] path = command.Split(' ');

        if (path[0] != "file" || path[1] != "show")
        {
            return Next?.Handle(command);
        }

        if (path.Length != 5 || path[3] != "-m")
        {
            return new UnknownCommand();
        }

        return new FileShowCommand(path[2], new PrintFile());
    }
}