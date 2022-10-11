using FluentAssertions;

namespace NexNet.Library.Tests;

public class ToolTests
{
    public class ConstructorTests
    {
        [Fact]
        public void CreateBasicInstanceTest()
        {
            var instance = new Tool();
            instance.Should().NotBeNull();
            instance.Name.Should().NotBeNull();
            instance.CuttingEdgeNumber.Should().Be(default);
            instance.Length.Should().BeNull();
        }        
        
        [Fact]
        public void SetToolNameTest()
        {
            foreach (var toolName in new[] {"EndMill", "Drill"})    
            {
                var instance = new Tool{Name = toolName};
                instance.Name.Should().NotBeNull();
                instance.Name.Should().Be(toolName);
                instance.Length.Should().BeNull();
            }
        }
        
        [Fact]
        public void SetToolNameAndLengthTest()
        {
            foreach (var (toolName, length, cuttingEdgeNumber) in new[] {("EndMill", 0, 1u), ("Drill", 10, 3u)})    
            {
                var instance = new Tool
                {
                    Name = toolName,
                    Length = length,
                    CuttingEdgeNumber = cuttingEdgeNumber
                };
                instance.Name.Should().NotBeNull();
                instance.Name.Should().Be(toolName);
                instance.Length.Should().NotBeNull();
                instance.Length.Should().Be(length);
                instance.CuttingEdgeNumber.Should().Be(cuttingEdgeNumber);
            }
        }
    }
}
