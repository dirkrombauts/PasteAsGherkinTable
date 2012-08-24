using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace PicklesDoc.PasteAsGherkinTable.Tests
{
  [TestClass]
  public class CellSizeCalculatorTests
  {
     [TestMethod]
     public void Calculate_NullArgument_ThrowsArgumentNullException()
     {
       var calculator = CreateCalculator();

       Should.Throw<ArgumentNullException>(() => calculator.Calculate(null));
     }

     [TestMethod]
     public void Calculate_ValidInput_DoesNotThrowArgumentNullException()
     {
       var calculator = CreateCalculator();

       Should.NotThrow(() => calculator.Calculate(new[] { new[] { "abc" } }));
     }

     [TestMethod]
     public void Calculate_ValidInput_ShouldReturnCorrectResult()
     {
       var calculator = CreateCalculator();

       var result = calculator.Calculate(new[] { new[] { "abc" } });

       result.ShouldBe(new[] { 3 });
     }

     [TestMethod]
     public void Calculate_ValidInput_ShouldReturnCorrectResult_2()
     {
       var calculator = CreateCalculator();

       var result = calculator.Calculate(new[] { new[] { "abcde" } });

       result.ShouldBe(new[] { 5 });
     }

     [TestMethod]
     public void Calculate_MultipleColumns_ShouldReturnCorrectResult()
     {
       var calculator = CreateCalculator();

       var result = calculator.Calculate(new[] { new[] { "abc", "uvxyz", "1234567890" } });

       result.ShouldBe(new[] { 3, 5, 10 });
     }

     [TestMethod]
     public void Calculate_MultipleLines_ShouldReturnCorrectResult()
     {
       var calculator = CreateCalculator();

       var result = calculator.Calculate(new[]
         {
           new[] { "abc" },
           new[] { "uvxyz" }
         });

       result.ShouldBe(new[] { 5 });
     }

     [TestMethod]
     public void Calculate_MultipleLinesAndColumns_ShouldReturnCorrectResult()
     {
       var calculator = CreateCalculator();

       var result = calculator.Calculate(new[]
         {
           new[] { "1", "uvxyzabcdef", "1234567890" },
           new[] { "abc", "uvxyz", "12345" }
         });

       result.ShouldBe(new[] { 3, 11, 10 });
     }

     [TestMethod]
     public void Calculate_MultipleColumnMissing_ShouldReturnCorrectResult()
     {
       var calculator = CreateCalculator();

       var result = calculator.Calculate(new[]
         {
           new[] { "1", "uvxyzabcdef", "1234567890" },
           new[] { "abc", "uvxyz" }
         });

       result.ShouldBe(new[] { 3, 11, 10 });
     }

     private static CellSizeCalculator CreateCalculator()
    {
      return new CellSizeCalculator();
    }
  }
}