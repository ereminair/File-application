using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Tree;

public class TreeGoToParser : Parser
{
    public override ICommand? Handle(string command)
    {
        string[] path = command.Split(' ');

        if (path[0] != "tree" || path[1] != "goto")
        {
            return Next?.Handle(command);
        }

        if (path.Length != 3)
        {
            return new UnknownCommand();
        }

        return new TreeGoToCommand(path[2]);
    }
}