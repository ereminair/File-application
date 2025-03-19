using Itmo.ObjectOrientedProgramming.Lab4.Systems.Struct;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public class FileSystem
{
    public string Path { get; set; }

    public FileSystemComponent? EntityFileSystem { get; set; }

    public FileSystem()
    {
        Path = string.Empty;
    }
}