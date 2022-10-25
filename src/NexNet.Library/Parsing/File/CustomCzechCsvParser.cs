namespace NexNet.Library.Parsing.File;

public class CustomCzechCsvParser : IParser 
{
    public (IEnumerable<Part> validParts, IEnumerable<Part> invalidParts) ValidateAssemblyContent(FileInfo assemblyFile)
    {
        if (!assemblyFile.Exists) return (Enumerable.Empty<Part>(), Enumerable.Empty<Part>());
        var parts = System.IO.File
                .ReadAllLines(assemblyFile.FullName)
                .Skip(1)
                .Select(GetPart)
                .ToList();
        return (parts.Where(p => p.FilePath.Exists), parts.Where(p => !p.FilePath.Exists));
    }

    private static Part GetPart(string line)
    {
        var result = line.Split(';');
        
        return new Part(
            new FileInfo(result[0]),
            result[1],
            uint.Parse(result[2]),
            result[4]
        );
    }
}