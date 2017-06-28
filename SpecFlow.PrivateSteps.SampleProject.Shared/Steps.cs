using System;
using PrivateSteps.SpecFlowPlugin;
using TechTalk.SpecFlow;

namespace SpecFlow.PrivateSteps.SampleProject.Shared
{
    [Binding]
    public class Steps
    {
        [When(@"I have a private step")]
        internal void WhenIHaveAPrivateStep()
        {
            Console.WriteLine("Private step");
        }
        
        [When(@"I have a public step")]
        public void WhenIHaveAPublicStep()
        {
            Console.WriteLine("Public step");
        }

        [Then(@"it is accessible for other projects")]
        [Then(@"it is not accessible for other projects")]
        public void ThenItIsNotAccessibleForOtherProjects()
        {
            //nop
        }
    }
}
