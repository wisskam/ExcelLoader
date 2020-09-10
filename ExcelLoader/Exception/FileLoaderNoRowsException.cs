using System;

public class FileLoaderNoRowsException : Exception
{
    public FileLoaderNoRowsException()
        : base("File loader - No rows detected\n")
    {
    }

    public FileLoaderNoRowsException(string message)
        : base("File loader - No rows detected\n" + message)
    {
    }

    public FileLoaderNoRowsException(string message, Exception inner)
        : base("File loader - No rows detected\n" + message, inner)
    {
    }
}
