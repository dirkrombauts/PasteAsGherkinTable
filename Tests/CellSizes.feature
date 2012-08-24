Feature: Cell Size Calculation
	In order to more easily read gherkin tables
	As a gherkin author
	I want tables to be aligned

Scenario: Table Cell Sizes
	Given I have this table
    """
    | header1      | header2           | header3                   |
    | content      | some more content |                           |
    | more content | small again       | really very large content |
    """
	When I calculate the column sizes
	Then the result should be
    | width |
    | 12    |
    | 17    |
    | 25    |
