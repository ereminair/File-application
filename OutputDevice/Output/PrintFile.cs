using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;

public class PrintFile : IPrinter
{
    public ResultPrint Print(string text)
    {
        if (File.Exists(text))
        {
            Console.WriteLine(File.ReadAllText(text));

            return new ResultPrint.PrintSuccess();
        }

        return new ResultPrint.FileNotFound();
    }
}