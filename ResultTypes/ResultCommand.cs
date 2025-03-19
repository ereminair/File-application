namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public record ResultCommand
{
    private ResultCommand() { }

    public sealed record CommandWasSuccess : ResultCommand;

    public sealed record NoFileSystem : ResultCommand;

    public sealed record NoValidPath : ResultCommand;

    public sealed record CommandExecutionError(string Error) : ResultCommand;
}