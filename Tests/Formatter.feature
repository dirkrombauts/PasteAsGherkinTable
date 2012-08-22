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
	  | verb | pronoun | adjective |
	  | isn't | that | cool? |
    """
