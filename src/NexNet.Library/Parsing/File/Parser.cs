using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using NexNet.Library.Extensions;

namespace NexNet.Library.Parsing.File;

public class Parser
{
    public static IEnumerable<FileInfo> GetFilesFromDirectory(string path, bool recursive = false)
    {
        if (!Directory.Exists(path)) return Enumerable.Empty<FileInfo>();
        var filesInDirectory = Directory.GetFiles(path);
        return filesInDirectory.Select(f => new FileInfo(f));
    }

    public static void PrintFileContent(FileInfo fileInfo)
    {
        Console.WriteLine(fileInfo.FullName);
        var content = string.Empty;
        try
        {
            content = System.IO.File.ReadAllText(fileInfo.FullName);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"The file {fileInfo.FullName} does not exists.");
        }
        catch (IOException e) when (e.HResult == Errors.HResultErrorCodes.FileIsInUseByAnotherProcess)
        {
            Console.WriteLine($"Please, close the file {fileInfo.FullName}");
        }        
        catch (Exception e)
        {
            Console.WriteLine($"Error on file {fileInfo.Name}. Error message: {e.Message}");
        }
        Console.WriteLine(content);
    }

    public static (IEnumerable<Part> validParts, IEnumerable<Part> invalidParts) ValidateAssemblyContent(
        FileInfo assemblyFile)
    {
        return (GetPartsFromFile(assemblyFile), Enumerable.Empty<Part>());
    }

    private static IEnumerable<Part> GetPartsFromFile(FileInfo assemblyFile)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
        };
        using var reader = new StreamReader(assemblyFile.FullName);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<Part>().ToList();
        records.ForEach(r => Console.WriteLine($"Path: {r.FilePath}, material: {r.Material}"));
        return records;
    }
}