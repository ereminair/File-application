using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;

public interface IFileSystemComponent
{
    public void Accept(IVisitor visitor);
}