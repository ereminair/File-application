﻿using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Tree;

public class TreeListParser : Parser
{
    public override ICommand? Handle(string command)
    {
        string[] path = command.Split(' ');

        if (path[0] != "tree" || path[1] != "list")
        {
            return Next?.Handle(command);
        }

        if (path.Length != 4 || path[2] != "-d")
        {
            return new UnknownCommand();
        }

        return new TreeListCommand(Convert.ToInt16(path[3]));
    }
}