using NexNet.Library.Extensions;
using NexNet.Library.Parsing.File;
using NexNet.Library.Parsing.File.Assembly;

namespace NexNet.FileParserConsoleApp;

public static class FileParserConsoleApp
{
    private static void Main(string[] inputArguments)
    {
        var customParser = new CustomCzechCsvParser();
        inputArguments.ForEach(path =>
        {
            Parser
                .GetFilesFromDirectory(path)
                .Where(f => f.IsCsv() && f.IsSingleFileAssembly())
                .ForEach(file =>
                {
                    Parser.PrintFileContent(file);
                    var (valid, invalid) = customParser.ValidateAssemblyContent(file);
                    valid.ForEach(validPart => Console.WriteLine($"{validPart.FilePath}"));
                });
        });
        Console.ReadKey();
    }
}