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
        try
        {
            Console.WriteLine(System.IO.File.ReadAllText(fileInfo.FullName));
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
    }
}