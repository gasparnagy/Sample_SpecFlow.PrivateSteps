using System;
using TechTalk.SpecFlow;

namespace SpecFlow.PrivateSteps.SampleProject.Consumer
{
    [Binding]
    public class Steps
    {
        [Then(@"I should not be able to use it here")]
        [Then(@"I should be able to use it here")]
        public void ThenIShouldBeAbleToUseItHere()
        {
            //nop
        }
    }
}
