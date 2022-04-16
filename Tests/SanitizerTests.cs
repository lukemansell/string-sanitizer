using FluentAssertions;
using StringSanitizer.StringSanitizer;
using StringSanitizer.StringSanitizer.Enums;
using Xunit;

namespace Tests;

public class SanitizerTests
{
    [Theory]
    [InlineData("❤", "")]
    [InlineData("❤❤!", "!")]
    [InlineData("🙌🏽", "")]
    [InlineData("Hello world!", "Hello world!")]
    public void EmojisAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeEmojis();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(" Hello", "Hello")]
    [InlineData("Hello", "Hello")]
    [InlineData("Hello ", "Hello ")]
    public void LeadingWhiteSpaceAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeLeadingEmptyCharacter();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello ", "Hello")]
    [InlineData(" Hello ", " Hello")]
    public void EndingWhiteSpaceAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeEndingEmptyCharacter();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(@"Hello 
there", "Hello there")]
    [InlineData(@"Hello
there", "Hellothere")]
    public void LineBreaksAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeLinebreaks();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello  world", "Hello world")]
    [InlineData("Hello    world", "Hello world")]
    [InlineData("Hello      world", "Hello world")]
    [InlineData("  Hello world", " Hello world")]
    [InlineData("Hello world", "Hello world")]
    public void ExcessiveSpacesAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeExcessiveSpaces();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("hello I am a spammer https://google.com", "hello I am a spammer ")]
    [InlineData("https://google.com/index", "")]
    [InlineData("HTTPS://GOOGLE.COM", "")]
    public void UrlsAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeUrls();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello world", "Hello world")]
    [InlineData("Hello-world", "Helloworld")]
    [InlineData("Hello 10 worlds", "Hello 10 worlds")]
    public void NonAlphanumericAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeNonAlphanumeric(SanitizeSpaces.False);
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello world", "Helloworld")]
    [InlineData("Hello-world", "Helloworld")]
    [InlineData("Hello 10 worlds", "Hello10worlds")]
    public void NonAlphanumericAndSpacesAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeNonAlphanumeric();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello world13", "Hello world")]
    [InlineData("Hello-world14", "Helloworld")]
    [InlineData("Hello 10 worlds", "Hello  worlds")]
    public void NumericAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeNumeric(SanitizeSpaces.False);
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello world13", "Helloworld")]
    [InlineData("Hello-world14", "Helloworld")]
    [InlineData("Hello 10 worlds", "Helloworlds")]
    public void NumericAndSpacesAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeNumeric();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    
    [Theory]
    [InlineData("5555555555554444", "")]
    [InlineData("5105105105105100", "")]
    [InlineData("4111111111111111", "")]
    [InlineData("4111-1111-1111-1111", "")]
    [InlineData("90210", "90210")]
    [InlineData("4111-1111-1111 hah prank", "4111-1111-1111 hah prank")]
    public void CreditCardsAreSanitizedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeCreditCard();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(" Hello❤", "Hello")]
    [InlineData("❤Hello", "Hello")]
    [InlineData("Hello ❤", "Hello ")]
    public void SanitizeFeaturesCanBeStacked(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitizeLeadingEmptyCharacter().SanitizeEmojis();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}