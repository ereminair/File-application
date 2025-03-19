using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingParameters;

public abstract class Parser : IParser
{
    protected IParser? Next { get; private set; }

    public IParser AddNext(IParser command)
    {
        if (Next is null)
        {
            Next = command;
        }
        else
        {
            Next.AddNext(command);
        }

        return this;
    }

    public abstract ICommand? Handle(string command);
}