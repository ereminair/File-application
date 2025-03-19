namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public record ResultPrint
{
    private ResultPrint() { }

    public sealed record PrintSuccess : ResultPrint;

    public sealed record FileNotFound : ResultPrint;
}