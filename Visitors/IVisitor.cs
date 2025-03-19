using Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IVisitor
{
    public void Visit(FileComponent component);

    public void Visit(DirectoryComponent component);
}