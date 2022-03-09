using System;
using TechTalk.SpecFlow;

namespace Tastease.FunctionalTests.StepDefinitions
{
    [Binding]
    public class AuthenticateUserStepDefinitions
    {
        [Given(@"guest user")]
        public void GivenGuestUser()
        {
            throw new PendingStepException();
        }

        [When(@"they attmept to use the application")]
        public void WhenTheyAttmeptToUseTheApplication()
        {
            throw new PendingStepException();
        }

        [Then(@"they presented with a register now panel")]
        public void ThenTheyPresentedWithARegisterNowPanel()
        {
            throw new PendingStepException();
        }
    }
}
