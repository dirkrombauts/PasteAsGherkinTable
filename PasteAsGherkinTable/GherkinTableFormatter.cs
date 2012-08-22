using System;
using System.Linq;

namespace Aim.PasteAsGherkinTable
{
  public class GherkinTableFormatter
  {
    public string Format(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
      {
        throw new ArgumentNullException();
      }

      string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

      var result = string.Join(Environment.NewLine, lines.Select(ProcessOneLine));

      return result;
    }

    private static string ProcessOneLine(string input)
    {
      string[] splitted = input.Split(';');

      string joined = string.Join(" | ", splitted);

      string resultOfOneLine = "| " + joined + " |";
      return resultOfOneLine;
    }
  }
}