using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;
using Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Connect;

public class ConnectParser : Parser
{
    public override ICommand? Handle(string command)
    {
        string[] path = command.Split(' ');

        if (path[0] != "connect")
        {
            return Next?.Handle(command);
        }

        var printer = new Printer();

        if (path.Length != 4 || path[2] != "-m")
        {
            return new UnknownCommand();
        }

        return new ConnectCommand(path[1], path[3], printer);
    }
}