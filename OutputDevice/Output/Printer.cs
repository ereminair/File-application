using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;

public class Printer : IPrinter
{
    public ResultPrint Print(string text)
    {
        Console.WriteLine(text);

        return new ResultPrint.PrintSuccess();
    }
}