# String Sanitizer

This [NuGet library](https://www.nuget.org/packages/Stax.StringSanitizer/) contains extension methods to Sanitize common issues with strings, removing the complexity to implement or use Regex to solve common issues.

### Features

* Remove emojis from a string
* Remove linebreaks from a string
* Remove URLs from a string
* Remove excessive spaces from a string (more than one occurrence of a space)
* Remove leading character if it is empty
* Remove ending character if it is empty
* Remove any non alphanumeric characters (with the option to disable/enable removing whitespaces too)
* Remove any numeric characters from a string (with the option to disable/enable removing whitespaces too)
* Remove credit cards from a string

### Why I have written this

There are many questions on the internet asking how to Sanitize strings such as removing spaces, linebreaks or emojis. I wanted to create an easy to use extension method to take away the complexity of having to look up and therefore implement Regex to projects.

### How to use

Once you have installed the StringSanitizer nuget package to your solution, you will be able to use this package. On any string you can add any of the methods listed below, and you can also chain them.

`string.SanitizeEmojis()`

`string.SanitizeLinebreaks()`

`string.SanitizeUrls()`

`string.SanitizeExcessiveSpaces()`

`string.SanitizeLeadingEmptyCharacter()`

`string.SanitizeNonAlphanumeric()`

`string.SanitizeNumeric()`

`string.SanitizeCreditCard()`

`string.SanitizeEndingEmptyCharacter()`

and an example of chaining them:

`string.SanitizeEmojis().SanitizeUrls().SanitizeExcessiveSpaces()`

You can also take advantage of `toString()` and then use any of these methods, if you wish to. Eg:

`number.toString().SanitizeNumeric()`