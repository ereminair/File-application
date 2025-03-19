using Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class PrintVisitor : IVisitor
{
    private readonly StringBuilder _result;
    private readonly int _depth;
    private int _count;

    public PrintVisitor(StringBuilder result, int depth)
    {
        _result = result;
        _depth = depth;
        _count = 0;
    }

    public void Visit(FileComponent component)
    {
        if (_count <= _depth)
        {
            _result.Append(new string(' ', _count * 2));
            _result.AppendLine($"file: {component.Name}");
        }
    }

    public void Visit(DirectoryComponent component)
    {
        if (_count <= _depth)
        {
            _result.Append(new string(' ', _count * 2));
            _result.AppendLine($"directory: {component.Name}");
            _count++;

            foreach (IFileSystemComponent child in component.Components)
            {
                child.Accept(this);
            }

            _count--;
        }
    }
}