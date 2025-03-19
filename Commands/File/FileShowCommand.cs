using Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class FileShowCommand : ICommand, IEquatable<FileShowCommand>
{
    private readonly string _path;
    private readonly PrintFile _mode;

    public FileShowCommand(string path, PrintFile printer)
    {
        _path = path;
        _mode = printer;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        if (localSystem.EntityFileSystem is null)
        {
            return new ResultCommand.NoFileSystem();
        }

        ResultPrint printResult = _mode.Print(_path);

        if (printResult is ResultPrint.FileNotFound)
        {
            return new ResultCommand.NoValidPath();
        }

        return new ResultCommand.CommandWasSuccess();
    }

    public bool Equals(FileShowCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path && _mode.Equals(other._mode);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FileShowCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, _mode);
    }
}