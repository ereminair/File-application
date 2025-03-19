using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public ResultCommand Execute(FileSystem localSystem);
}