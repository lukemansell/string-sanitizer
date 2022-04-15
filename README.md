# String Sanitiser

This NuGet library contains extension methods to sanitise common issues with strings, removing the complexity to implement or use Regex to solve common issues.

### Features

* Remove emojis from a string
* Remove linebreaks from a string
* Remove URLs from a string
* Remove excessive spaces from a string (more than one occurrence of a space)
* Remove leading character if it is empty
* Remove ending character if it is empty
* Remove any non alphanumeric characters (with the option to disable/enable removing whitespaces too)
* Remove any numeric characters from a string (with the option to disable/enable removing whitespaces too)

### Why I have written this

There are many questions on the internet asking how to sanitise strings such as removing spaces, linebreaks or emojis. I wanted to create an easy to use extension method to take away the complexity of having to look up and therefore implement Regex to projects.

### How to use

Once you have installed the StringSanitiser nuget package to your solution, you will be able to use this package. On any string you can add any of the methods listed below, and you can also chain them.

`string.SanitiseEmojis()`

`string.SanitiseLinebreaks()`

`string.SanitiseUrls()`

`string.SanitiseExcessiveSpaces()`

`string.SanitiseLeadingEmptyCharacter()`

`string.SanitiseNonAlphanumeric()`

`string.SanitiseNumeric()`

`string.SanitiseEndingEmptyCharacter()`

and an example of chaining them:

`string.SanitiseEmojis().SanitiseUrls().SanitiseExcessiveSpaces()`

You can also take advantage of `toString()` and then use any of these methods, if you wish to. Eg:

`number.toString().SanitiseNumeric()`