using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ResponsibilityChain;

public class CommandParser : IParser
{
    private readonly IParser? _firstCommand;

    public CommandParser()
    {
        _firstCommand = new ConnectParser()
            .AddNext(new DisconnectParser())
            .AddNext(new FileCopyParser())
            .AddNext(new FileDeleteParser())
            .AddNext(new FileMoveParser())
            .AddNext(new FileRenameParser())
            .AddNext(new FileShowParser())
            .AddNext(new TreeGoToParser())
            .AddNext(new TreeListParser());
    }

    public IParser AddNext(IParser command)
    {
        return this;
    }

    public ICommand? Handle(string command)
    {
        return _firstCommand?.Handle(command);
    }
}