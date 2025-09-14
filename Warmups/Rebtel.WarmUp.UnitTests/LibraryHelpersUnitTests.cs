using Xunit;
using Rebtel.WarmUp;

namespace Rebtel.WarmUp.UnitTests;

public class LibraryHelpersUnitTests
{
    #region IsPowOfTwo Tests

    [Theory]
    [InlineData(256)]   // 2^0
    [InlineData(1024)] // 2^10
    public void IsPowOfTwo_WithPowerOfTwoNumbers_ReturnsTrue(int number)
    {
        // Act & Assert
        Assert.True(LibraryHelpers.IsPowOfTwo(number));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(5)]
    public void IsPowOfTwo_WithNonPowerOfTwoNumbers_ReturnsFalse(int number)
    {
        // Act & Assert
        Assert.False(LibraryHelpers.IsPowOfTwo(number));
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(-4)]
    [InlineData(-8)]
    public void IsPowOfTwo_WithNegativeNumbers_ReturnsFalse(int number)
    {
        // Act & Assert
        Assert.False(LibraryHelpers.IsPowOfTwo(number));
    }

    #endregion

    #region ReverseBookTitle Tests

    [Theory]
    [InlineData("The Great Gatsby", "ybstaG taerG ehT")]
    [InlineData("A", "A")]
    [InlineData("madam", "madam")]
    [InlineData("Hello, World!", "!dlroW ,olleH")]
    public void ReverseBookTitle_WithValidString_ReturnsReversedString(string bookTitle, string expected)
    {
        // Act
        var result = LibraryHelpers.ReverseBookTitle(bookTitle);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ReverseBookTitle_WithNullOrEmptyString_ThrowsArgumentException(string bookTitle)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => LibraryHelpers.ReverseBookTitle(bookTitle));
        Assert.Equal("Book Title Cannot Be Empty", exception.Message);
    }

    #endregion

    #region ReplicateString Tests

    [Theory]
    [InlineData("Hello", 3, "HelloHelloHello")]
    [InlineData("A", 5, "AAAAA")]
    [InlineData("Test", 1, "Test")]
    public void ReplicateString_WithValidInputAndCount_ReplicatesCorrectly(string input, int count, string expected)
    {
        // Act
        var result = LibraryHelpers.ReplicateString(input, count);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Test", 0)]
    [InlineData("Test", -1)]
    public void ReplicateString_WithInvalidCount_ThrowsArgumentException(string input, int count)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => LibraryHelpers.ReplicateString(input, count));
        Assert.Equal("Count must be greater than zero", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ReplicateString_WithInvalidTitle_ThrowsArgumentException(string bookTitle)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => LibraryHelpers.ReplicateString(bookTitle, 1));
        Assert.Equal("Input cannot be empty", exception.Message);
    }

    #endregion

    #region GetOddNumbers Tests

    [Fact]
    public void GetOddNumbers_WithDefaultParameters_ReturnsOddNumbersFromZeroToHundred()
    {
        // Act
        var result = LibraryHelpers.GetOddNumbers().ToList();

        // Assert
        Assert.Equal(50, result.Count); // 50 odd numbers from 1 to 99
        Assert.Equal(1, result.First());
        Assert.Equal(99, result.Last());
        Assert.All(result, number => Assert.True(number % 2 != 0));
    }

    [Fact]
    public void GetOddNumbers_WithLargeRange_ReturnsCorrectCount()
    {
        // Act
        var result = LibraryHelpers.GetOddNumbers().ToList();

        // Assert
        Assert.Equal(500, result.Count); // 500 odd numbers from 1 to 999
        Assert.All(result, number => Assert.True(number % 2 != 0));
    }

    #endregion
}