# PasteAsGherkinTable

A Visual Studio 2012 plugin that pastes CSV data from the clipboard as a Gherkin table.

## Example

Given the clipboard contains

	verb;pronoun;adjective
	isn't;that;cool?

Then the plugin will paste

	| verb  | pronoun | adjective |
	| isn't | that    | cool?     |
