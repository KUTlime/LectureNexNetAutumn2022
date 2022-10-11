using FluentAssertions;

namespace NexNet.Library.Tests;

public class MeasurementTests
{
    public class ConstructorTests
    {
        private const double NominalValue = 10.0;
        private const double MeasuredValue = 9.5;
        [Fact]
        void RadialMeasurementCalculationShouldBeNominalMinusMeasuredTest()
        {
            // Arrange
            
            // Act
            MeasurementBase radialMeasurement = new RadialMeasurement(NominalValue);
            radialMeasurement.MeasuredValue = MeasuredValue;
            // Assert
            
            radialMeasurement.NominalValue.Should().Be(NominalValue);
            radialMeasurement.MeasuredValue.Should().Be(MeasuredValue);
            radialMeasurement.Difference.Should().Be(NominalValue - MeasuredValue);
        } 
        
        [Fact]
        void UpdateMeasuredValueShouldUpdateDifferenceTest()
        {
            // Arrange
            MeasurementBase radialMeasurement = new RadialMeasurement(NominalValue);
            radialMeasurement.MeasuredValue = MeasuredValue;
            var firstDifference = radialMeasurement.Difference;
            // Act
            const double newMeasurementValue = MeasuredValue + 1.0;
            radialMeasurement.MeasuredValue = newMeasurementValue;
            // Assert
            radialMeasurement.NominalValue.Should().Be(NominalValue);
            radialMeasurement.MeasuredValue.Should().Be(newMeasurementValue);
            radialMeasurement.Difference.Should().NotBe(firstDifference);
            radialMeasurement.Difference.Should().Be(NominalValue - newMeasurementValue);
        } 
    }
}