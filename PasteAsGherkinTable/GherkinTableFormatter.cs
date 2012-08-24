using System;
using System.Collections.Generic;
using System.Linq;

namespace PicklesDoc.PasteAsGherkinTable
{
  public class GherkinTableFormatter
  {
    private readonly CellSizeCalculator cellSizeCalculator;

    public GherkinTableFormatter()
    {
      this.cellSizeCalculator = new CellSizeCalculator();
    }

    public string Format(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
      {
        throw new ArgumentNullException();
      }

      string[][] table = SplitIntoTable(input);

      int[] columnWidths = this.cellSizeCalculator.Calculate(table);

      IEnumerable<string> formattedLines = Enumerable.Range(0, table.Length).Select(row => ProcessOneLine(columnWidths, table[row]));

      var result = string.Join(Environment.NewLine, formattedLines);

      return result;
    }

    private static string[][] SplitIntoTable(string input)
    {
      if (ShouldReplace(input))
      {
        input = input.Replace(",", ";");
      }

      string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

      string[][] table = lines.Select(l => l.Split(';').Select(cell => cell.Trim()).ToArray()).ToArray();
      return table;
    }

    private static bool ShouldReplace(string input)
    {
      return input.Count(c => c == ',') > input.Count(c => c == ';');
    }

    private static string ProcessOneLine(int[] columnWidths, IEnumerable<string> cells)
    {
      List<string> paddedCells = cells.Select((s, cellIndex) => s.PadRight(columnWidths[cellIndex])).ToList();

      string joined = string.Join(" | ", paddedCells);

      string resultOfOneLine = "| " + joined + " |";
      return resultOfOneLine;
    }
  }
}