using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;

public class FileComponent : IFileSystemComponent
{
    public string Name { get; }

    public FileComponent(string name)
    {
        Name = name;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}