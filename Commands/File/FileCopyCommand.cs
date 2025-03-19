﻿using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class FileCopyCommand : ICommand, IEquatable<FileCopyCommand>
{
    private readonly string _soursPath;
    private readonly string _destinationPath;

    public FileCopyCommand(string soursPath, string destinationPath)
    {
        _soursPath = soursPath;
        _destinationPath = destinationPath;
    }

    public ResultCommand Execute(FileSystem localSystem)
    {
        if (localSystem.EntityFileSystem is null)
        {
            return new ResultCommand.NoFileSystem();
        }

        if (System.IO.File.Exists(_soursPath))
        {
            System.IO.File.Copy(_soursPath, _destinationPath);

            return new ResultCommand.CommandWasSuccess();
        }

        return new ResultCommand.NoValidPath();
    }

    public bool Equals(FileCopyCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _soursPath == other._soursPath && _destinationPath == other._destinationPath;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FileCopyCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_soursPath, _destinationPath);
    }
}