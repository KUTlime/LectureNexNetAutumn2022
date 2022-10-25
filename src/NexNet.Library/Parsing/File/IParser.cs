namespace NexNet.Library.Parsing.File;

public interface IParser
{
    public (IEnumerable<Part> validParts, IEnumerable<Part> invalidParts) ValidateAssemblyContent(FileInfo assemblyFile);
}