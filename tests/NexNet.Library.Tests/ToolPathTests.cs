using FluentAssertions;

namespace NexNet.Library.Tests;

public class ToolPathTests
{
    const double PreviousToolPathValue = 10.5;

    public class ConstructorTests
    {
        [Fact]
        void BasicEmptyPathInitializationTest()
        {
            var toolPath = new ToolPath();
            toolPath.Value.Should().Be(default);
        }
        
        [Fact]
        void CreateFromValueTest()
        {
            var toolPath = new ToolPath(PreviousToolPathValue);
            toolPath.Value.Should().Be(PreviousToolPathValue);
        }
    }

    public class AddPathLengthTests
    {
        [Fact]
        void AddZeroPathShouldNotModifyTotalPath()
        {
            var toolPath = new ToolPath();
            toolPath.AddPathLength(0);
            toolPath.Value.Should().Be(default);
        }
        
        [Fact]
        void AddValueShouldBeCorrectlyAdded()
        {
            // Arrange
            const double currentlyProcessedPathValue = 5.5;
            var toolPath = new ToolPath(PreviousToolPathValue);
            // Act
            toolPath.AddPathLength(currentlyProcessedPathValue);
            // Assert
            toolPath.Value.Should().Be(PreviousToolPathValue + currentlyProcessedPathValue);
        } 
    }
}