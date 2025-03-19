using Itmo.ObjectOrientedProgramming.Lab4.OutputDevice.Output;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;
using Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

public class TreeListCommand : ICommand, IEquatable<TreeListCommand>
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        if (localSystem.EntityFileSystem is null)
        {
            return new ResultCommand.NoFileSystem();
        }

        var print = new Printer();
        var result = new StringBuilder();

        TreeList(_depth, localSystem.Path, result);
        print.Print(result.ToString());

        return new ResultCommand.CommandWasSuccess();
    }

    public bool Equals(TreeListCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _depth == other._depth;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TreeListCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_depth);
    }

    private static void TreeList(int depth, string path, StringBuilder result)
    {
        if (depth < 0)
        {
            return;
        }

        string[] directories = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);

        var directoryComponent = new DirectoryComponent(Path.GetFileName(path));

        foreach (string directory in directories)
        {
            var nameDirectory = new DirectoryComponent(Path.GetFileName(directory));
            directoryComponent.AddComponent(nameDirectory);

            TreeList(depth - 1, directory, result);
        }

        foreach (string file in files)
        {
            var fileName = new FileComponent(Path.GetFileName(file));
            directoryComponent.AddComponent(fileName);
        }

        var printer = new PrintVisitor(result, depth);
        directoryComponent.Accept(printer);
    }
}