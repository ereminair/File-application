using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Disconnect;

public class DisconnectCommand : ICommand, IEquatable<DisconnectCommand>
{
    public ResultCommand Execute(FileSystem localSystem)
    {
        localSystem.Path = string.Empty;
        localSystem.EntityFileSystem = null;

        return new ResultCommand.CommandWasSuccess();
    }

    public bool Equals(DisconnectCommand? other)
    {
        return other is not null;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DisconnectCommand)obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}