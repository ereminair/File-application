using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var localSystem = new FileSystem();
        var commandParser = new CommandParser();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            ICommand? command = commandParser.Handle(input);

            if (command != null)
            {
                ResultCommand result = command.Execute(localSystem);

                if (result is ResultCommand.CommandWasSuccess)
                {
                    Console.WriteLine("The command was executed successfully.");
                }
                else if (result is ResultCommand.NoFileSystem)
                {
                    Console.WriteLine("Error: The file system is not connected.");
                }
                else
                {
                    Console.WriteLine("Error: Incorrect path.");
                }
            }
            else
            {
                Console.WriteLine("The command could not be recognized.");
            }
        }
    }
}