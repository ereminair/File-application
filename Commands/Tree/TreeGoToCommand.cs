using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

public class TreeGoToCommand : ICommand, IEquatable<TreeGoToCommand>
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        if (localSystem.EntityFileSystem is null)
        {
            return new ResultCommand.NoFileSystem();
        }

        if (Directory.Exists(_path) is false)
        {
            return new ResultCommand.NoValidPath();
        }

        localSystem.Path = _path;

        return new ResultCommand.CommandWasSuccess();
    }

    public bool Equals(TreeGoToCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TreeGoToCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path);
    }
}