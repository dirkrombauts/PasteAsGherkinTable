using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aim.PasteAsGherkinTable.Tests
{
  [TestClass]
  public class GherkinTableFormatterTest
  {
    [TestMethod]
    public void Format_NullInput_ThrowsArgumentNullException()
    {
      var formatter = CreateFormatter();

      Should.Throw<ArgumentNullException>(() => formatter.Format(null));
    }

    [TestMethod]
    public void Format_NonEmptyInput_DoesNotThrowArgumentNullException()
    {
      var formatter = CreateFormatter();

      Should.NotThrow(() => formatter.Format("abc"));
    }

    [TestMethod]
    public void Format_WhiteSpaceInput_ThrowsArgumentNullException()
    {
      var formatter = CreateFormatter();

      Should.Throw<ArgumentNullException>(() => formatter.Format("        "));
    }

    [TestMethod]
    public void Format_ValidInput_OutputShouldStartWithPipe()
    {
      var formatter = CreateFormatter();

      string output = formatter.Format("header");

      output.ShouldStartWith("|");
    }

    [TestMethod]
    public void Format_SingleLineSingleColumn_OutputShouldStartAndEndWithPipe()
    {
      var formatter = CreateFormatter();

      string output = formatter.Format("header");

      output.ShouldBe("| header |");
    }

    [TestMethod]
    public void Format_SingleLineTwoColumns_OutputShouldContainAPipeInTheMiddle()
    {
      var formatter = CreateFormatter();

      string output = formatter.Format("header1;header2");

      output.ShouldBe("| header1 | header2 |");
    }

    [TestMethod]
    public void Format_TwoLines_OutputShouldContainNewLine()
    {
      var formatter = CreateFormatter();

      string output = formatter.Format("header1" + Environment.NewLine + "value_1");

      output.ShouldBe("| header1 |" + Environment.NewLine + "| value_1 |");
    }

    private static GherkinTableFormatter CreateFormatter()
    {
      return new GherkinTableFormatter();
    }
  }
}