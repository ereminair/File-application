using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _components;

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Components => _components.AsReadOnly();

    public DirectoryComponent(string name)
    {
        Name = name;
        _components = new List<IFileSystemComponent>();
    }

    public void AddComponent(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (IFileSystemComponent child in Components)
        {
            child.Accept(visitor);
        }
    }
}