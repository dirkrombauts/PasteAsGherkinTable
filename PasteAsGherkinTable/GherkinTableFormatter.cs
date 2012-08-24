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

      string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

      string[][] table = lines.Select(l => l.Split(';')).ToArray();

      int[] sizes = this.cellSizeCalculator.Calculate(table);

      IEnumerable<string> formattedLines = Enumerable.Range(0, table.Length).Select(row => ProcessOneLine(sizes, table[row]));

      var result = string.Join(Environment.NewLine, formattedLines);

      return result;
    }

    private static string ProcessOneLine(int[] columnWidths, string[] cells)
    {
      List<string> paddedCells = cells.Select((s, cellIndex) => s + new string(' ', columnWidths[cellIndex] - s.Length)).ToList();

      string joined = string.Join(" | ", paddedCells);

      string resultOfOneLine = "| " + joined + " |";
      return resultOfOneLine;
    }
  }
}