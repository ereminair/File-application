using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;

public interface IPrinter
{
    public ResultPrint Print(string text);
}