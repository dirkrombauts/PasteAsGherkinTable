using System;
using Shouldly;
using TechTalk.SpecFlow;

namespace PicklesDoc.PasteAsGherkinTable.Tests
{
    [Binding]
    public class FormatterSteps
    {
        [Given(@"the clipboard contains")]
        public void GivenTheClipboardContains(string multilineText)
        {
          ScenarioContext.Current["Clipboard"] = multilineText;
        }
        
        [When(@"I invoke ""Paste As Gherkin Table""")]
        public void WhenIInvoke()
        {
          string input = (string)ScenarioContext.Current["Clipboard"];

          string output = new GherkinTableFormatter().Format(input);

          ScenarioContext.Current["Pasted"] = output;
        }

      [Then(@"the following should be pasted")]
        public void ThenTheFollowingShouldBePasted(string multilineText)
        {
          string pasted = (string)ScenarioContext.Current["Pasted"];

          pasted.ShouldBe(multilineText);
        }
    }
}
