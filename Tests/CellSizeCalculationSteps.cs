using System;
using System.Linq;
using Shouldly;
using TechTalk.SpecFlow;

namespace PicklesDoc.PasteAsGherkinTable.Tests
{
    [Binding]
    public class CellSizeCalculationSteps
    {
        [Given(@"I have this table")]
        public void GivenIHaveThisTable(string multilineText)
        {
          string[][] table = multilineText
            .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            .Select(line => line.Trim())
            .Select(line => line.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).Select(cell => cell.Trim()).ToArray())
            .ToArray();

          ScenarioContext.Current["Table"] = table;
        }
        
        [When(@"I calculate the column sizes")]
        public void WhenICalculateTheColumnSizes()
        {
          string[][] table = (string[][])ScenarioContext.Current["Table"];

          int[] result = new CellSizeCalculator().Calculate(table);

          ScenarioContext.Current["Sizes"] = result;
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
          int[] sizes = (int[])ScenarioContext.Current["Sizes"];

          table.RowCount.ShouldBe(sizes.Length);

          for (int i = 0; i < sizes.Length; i++)
          {
            int actualWidth = int.Parse(table.Rows[i]["width"]);

            actualWidth.ShouldBe(sizes[i]);
          }
        }
    }
}
