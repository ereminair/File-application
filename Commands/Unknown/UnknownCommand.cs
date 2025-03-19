using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Unknown;

public class UnknownCommand : ICommand, IEquatable<UnknownCommand>
{
    public ResultCommand Execute(FileSystem localSystem)
    {
        return new ResultCommand.CommandExecutionError("Unknown command");
    }

    public bool Equals(UnknownCommand? other)
    {
        return other is not null;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UnknownCommand)obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}