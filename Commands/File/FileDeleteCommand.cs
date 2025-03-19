using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class FileDeleteCommand : ICommand, IEquatable<FileDeleteCommand>
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        if (localSystem.EntityFileSystem is null)
        {
            return new ResultCommand.NoFileSystem();
        }

        if (System.IO.File.Exists(_path))
        {
            System.IO.File.Delete(_path);

            return new ResultCommand.CommandWasSuccess();
        }

        return new ResultCommand.NoValidPath();
    }

    public bool Equals(FileDeleteCommand? other)
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
        return Equals((FileDeleteCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path);
    }
}