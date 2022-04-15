using FluentAssertions;
using StringSanitiser.StringSanitiser;
using StringSanitiser.StringSanitiser.Enums;
using Xunit;

namespace Tests;

public class SanitiserTests
{
    [Theory]
    [InlineData("❤", "")]
    [InlineData("❤❤!", "!")]
    [InlineData("🙌🏽", "")]
    [InlineData("Hello world!", "Hello world!")]
    public void EmojisAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseEmojis();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(" Hello", "Hello")]
    [InlineData("Hello", "Hello")]
    [InlineData("Hello ", "Hello ")]
    public void LeadingWhiteSpaceAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseLeadingEmptyCharacter();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello ", "Hello")]
    [InlineData(" Hello ", " Hello")]
    public void EndingWhiteSpaceAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseEndingEmptyCharacter();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello  world", "Hello world")]
    [InlineData("Hello    world", "Hello world")]
    [InlineData("Hello      world", "Hello world")]
    [InlineData("  Hello world", " Hello world")]
    [InlineData("Hello world", "Hello world")]
    public void ExcessiveSpacesAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseExcessiveSpaces();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("hello I am a spammer https://google.com", "hello I am a spammer ")]
    [InlineData("https://google.com/index", "")]
    [InlineData("HTTPS://GOOGLE.COM", "")]
    public void UrlsAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseUrls();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello world", "Hello world")]
    [InlineData("Hello-world", "Helloworld")]
    [InlineData("Hello 10 worlds", "Hello 10 worlds")]
    public void NonAlphanumericAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseNonAlphanumeric(SanitiseSpaces.False);
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("Hello world", "Helloworld")]
    [InlineData("Hello-world", "Helloworld")]
    [InlineData("Hello 10 worlds", "Hello10worlds")]
    public void NonAlphanumericAndSpacesAreSanitisedFromString(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseNonAlphanumeric();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(" Hello❤", "Hello")]
    [InlineData("❤Hello", "Hello")]
    [InlineData("Hello ❤", "Hello ")]
    public void AllSanitiseFeaturesCanBeStacked(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = input.SanitiseLeadingEmptyCharacter().SanitiseEmojis();
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}