using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class FileRenameCommand : ICommand, IEquatable<FileRenameCommand>
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        if (localSystem.EntityFileSystem is null)
        {
            return new ResultCommand.NoFileSystem();
        }

        var newPath = new StringBuilder(_path);
        int count = newPath.Length - 1;

        while (count != 0 && newPath[count] != '\\')
        {
            count--;
        }

        string resultPath = newPath.ToString(0, count) + "\\" + _name;

        if (System.IO.File.Exists(_path))
        {
            System.IO.File.Move(_path, resultPath);

            return new ResultCommand.CommandWasSuccess();
        }

        return new ResultCommand.NoValidPath();
    }

    public bool Equals(FileRenameCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path && _name == other._name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FileRenameCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, _name);
    }
}