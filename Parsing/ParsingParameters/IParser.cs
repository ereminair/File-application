using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

public interface IParser
{
    public IParser AddNext(IParser command);

    public ICommand? Handle(string command);
}