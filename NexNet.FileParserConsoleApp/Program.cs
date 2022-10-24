using NexNet.Library.Extensions;
using NexNet.Library.Parsing.File;
using NexNet.Library.Parsing.File.Assembly;

namespace NexNet.FileParserConsoleApp;

public static class FileParserConsoleApp
{
    private static void Main(string[] inputArguments)
    {
        inputArguments.ForEach(path =>
        {
            Parser
                .GetFilesFromDirectory(path)
                .Where(f => f.IsCsv() && f.IsSingleFileAssembly())
                .ForEach(Parser.PrintFileContent);
        });
        Console.ReadKey();
    }
}