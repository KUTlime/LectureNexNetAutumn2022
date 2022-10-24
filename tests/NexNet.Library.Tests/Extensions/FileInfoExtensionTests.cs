using FluentAssertions;
using NexNet.Library.Extensions;
using NexNet.Library.Parsing.File.Assembly;

namespace NexNet.Library.Tests.Extensions;


public static class FileInfoExtensionTests
{
    public class IsSingleFileAssemblyTests
    {
        [Fact]
        private void RandomFileNameShouldNotBeAValidFileAssemblyCsv()
        {
            var fileInfo = new FileInfo("asdfasdfasdfasdf.csv");
            fileInfo.IsSingleFileAssembly().Should().BeFalse();
        }
        
        [Fact]
        private void FileWithoutExtensionShouldNotBeAValidFileAssemblyCsv()
        {
            var fileInfo = new FileInfo("asdfasdfasdfasdf");
            fileInfo.IsSingleFileAssembly().Should().BeFalse();
        }
        
        [Fact]
        private void ValidSingleFileAssemblyProduceValidResult()
        {
            var fileInfo = new FileInfo("CorrectSamostatne.csv");
            fileInfo.IsSingleFileAssembly().Should().BeTrue();
        }
        
        [Fact]
        private void ValidSingleFileWithoutExtensionAssemblyProduceInvalidResult()
        {
            var fileInfo = new FileInfo("CorrectSamostatne");
            fileInfo.IsSingleFileAssembly().Should().BeFalse();
        }
    }

    public class GetFileNameWithoutExtensionTests
    {
        [Fact]
        private void ValidFileNameShouldProduceValidResult()
        {
            GenerateFileTest(testFileName: "Test", testFileExtension: ".csv");
        }
        
        [Fact]
        private void EmptyFileNameShouldProduceEmptyResult()
        {
            GenerateFileTest(testFileName: "", testFileExtension: ".csv");
        }

        [Fact]
        private void FileWithoutExtensionShouldProduceValidResult()
        {
            GenerateFileTest("Test");
        }

        private static void GenerateFileTest(string testFileName, string testFileExtension = "")
        {
            var fileInfoFullName = testFileExtension switch
            {
                // { } znamená, že tady má být nějaká validní string hodnota, u které rovnou mohu kontrolovat vlastnosti.
                { Length: > 0 } when testFileExtension[0] == '.' => $"{testFileName}{testFileExtension}",
                { Length: > 0 } when testFileExtension[0] != '.' => $"{testFileName}.{testFileExtension}",
                "" => $"{testFileName}",
                _ => $"{testFileName}"
            };
            var fileInfo = new FileInfo(fileInfoFullName);
            var basicFileName = fileInfo.GetFileNameWithoutExtension();
            basicFileName.Should().Be(testFileName);
        }
    }
}