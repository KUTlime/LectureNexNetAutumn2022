using NexNet.Library.Extensions;
namespace NexNet.Library.Parsing.File.Assembly;

public static class FileInfoExtension
{
    public static bool IsSingleFileAssembly(this FileInfo file) => string.CompareOrdinal(file.GetFileNameWithoutExtension().ToLowerInvariant(),  IdentificationStrategy.GetSinglePartFileNameLowerInvariant()) == 0;
}


