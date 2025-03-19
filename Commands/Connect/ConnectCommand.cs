using Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;
using Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect;

public class ConnectCommand : ICommand, IEquatable<ConnectCommand>
{
    private readonly string _path;
    private readonly string _model;
    private readonly IPrinter _printer;

    public ConnectCommand(string path, string model, IPrinter printer)
    {
        _path = path;
        _model = model;
        _printer = printer;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        localSystem.Path = _path;
        localSystem.EntityFileSystem = new FileSystemComponent();

        _printer.Print($"Connect to {_path} in {_model} mode.");

        return new ResultCommand.CommandWasSuccess();
    }

    public bool Equals(ConnectCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path && _model == other._model && _printer.Equals(other._printer);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ConnectCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, _model, _printer);
    }
}