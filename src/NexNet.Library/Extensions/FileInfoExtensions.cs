namespace NexNet.Library.Extensions;

public static class FileInfoExtensions
{
    public static bool IsCsv(this FileInfo file) => string.CompareOrdinal(file.Extension.ToLowerInvariant(), ".csv") == 0;

    public static string GetFileNameWithoutExtension(this FileInfo file) => file.Name.Contains('.') ? file.Name.Split('.', StringSplitOptions.TrimEntries)[^2] : file.Name;
}