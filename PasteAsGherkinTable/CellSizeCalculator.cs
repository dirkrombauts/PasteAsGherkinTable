using System;
using System.Collections.Generic;
using System.Linq;

namespace PicklesDoc.PasteAsGherkinTable
{
  public class CellSizeCalculator
  {
    public int[] Calculate(string[][] table)
    {
      if (table == null)
      {
        throw new ArgumentNullException();
      }

      int[][] sizes = table.Select(row => row.Select(cell => cell.Length).ToArray()).ToArray();

      int maximumNumberOfColumns = sizes.Select(sizeRow => sizeRow.Length).Max();

      List<int> calculatedSize = new List<int>();

      for (int i = 0; i < maximumNumberOfColumns; i++)
      {
        calculatedSize.Add(sizes.Select(oneRow => i < oneRow.Length ? oneRow[i] : 0).Max());
      }

      return calculatedSize.ToArray();
    }
  }
}