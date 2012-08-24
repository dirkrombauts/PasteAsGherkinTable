Feature: Formatter
	In order to avoid manual work
	As a gherkin writer
	I want to past CSV data as a Gherkin table

Scenario: Simple Formatting
	Given the clipboard contains
    """
    verb;pronoun;adjective
	  isn't;that;cool?
    """
	When I invoke "Paste As Gherkin Table"
	Then the following should be pasted
    """
	  | verb  | pronoun | adjective |
	  | isn't | that    | cool?     |
    """

Scenario: Simple Formatting with large content
	Given the clipboard contains
    """
    verb;pronoun;adjective
	  isn't;that;extremely cool?
    """
	When I invoke "Paste As Gherkin Table"
	Then the following should be pasted
    """
	  | verb  | pronoun | adjective       |
	  | isn't | that    | extremely cool? |
    """

Scenario: Simple Formatting with commas
	Given the clipboard contains
    """
    verb,pronoun,adjective
	  isn't,that,cool?
    """
	When I invoke "Paste As Gherkin Table"
	Then the following should be pasted
    """
	  | verb  | pronoun | adjective |
	  | isn't | that    | cool?     |
    """

Scenario: Correct Recognition of commas and semicolons
	Given the clipboard contains
    """
    verb;pronoun;adjective
	  isn't;that, you know,;cool?
    """
	When I invoke "Paste As Gherkin Table"
	Then the following should be pasted
    """
	  | verb  | pronoun         | adjective |
	  | isn't | that, you know, | cool?     |
    """
