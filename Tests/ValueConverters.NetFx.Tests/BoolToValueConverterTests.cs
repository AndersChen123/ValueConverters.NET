﻿using System.Windows.Data;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class BoolToValueConverterTests
    {
        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter converter = new BoolToValueConverter<string> { TrueValue = "Yes", FalseValue = "No" };

            const string ExpectedValue = "Yes";
            object input = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(convertedOutput, ExpectedValue);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter converter = new BoolToValueConverter<string> { TrueValue = "Yes", FalseValue = "No" };

            const string Input = "Yes";
            const bool ExpectedOutput = true;

            // Act
            var convertedOutput = converter.ConvertBack(Input, null, null, null);

            // Assert
            Assert.Equal(convertedOutput, ExpectedOutput);
        }
    }
}
