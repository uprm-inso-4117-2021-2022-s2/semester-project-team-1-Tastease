using System;
using Tastease.UnitTests.PageModels;
using TechTalk.SpecFlow;

namespace Tastease.IntegrationTests.StepDefinitions
{
    [Binding]
    public class UserAuthenticationStepDefinitions
    {
        private readonly AuthenticationPageModel _authenticationPageModel;

        public UserAuthenticationStepDefinitions(AuthenticationPageModel authenticationPageModel) 
        {

            _authenticationPageModel = authenticationPageModel;
        }

        [Given(@"unique unregistered email and password")]
        public async Task GivenUniqueUnregisteredEmailAndPassword()
        {
            await _authenticationPageModel.IntializeContextAsync("", "");
        }

        [When(@"user clicks the submit button")]
        public void WhenUserClicksTheSubmitButton()
        {
            throw new PendingStepException();
        }

        [Then(@"the user is registered")]
        public void ThenTheUserIsRegistered()
        {
            throw new PendingStepException();
        }

        [Then(@"the user can see that they are verified")]
        public void ThenTheUserCanSeeThatTheyAreVerified()
        {
            throw new PendingStepException();
        }

        [When(@"user enters existing credentials")]
        public void WhenUserEntersExistingCredentials()
        {
            throw new PendingStepException();
        }

        [Then(@"the user is notified that the email is registered")]
        public void ThenTheUserIsNotifiedThatTheEmailIsRegistered()
        {
            throw new PendingStepException();
        }

        [Given(@"guest user")]
        public void GivenGuestUser()
        {
            throw new PendingStepException();
        }

        [When(@"the guest user provides preexisting email and password")]
        public void WhenTheGuestUserProvidesPreexistingEmailAndPassword()
        {
            throw new PendingStepException();
        }

        [Then(@"the user is authenticated")]
        public void ThenTheUserIsAuthenticated()
        {
            throw new PendingStepException();
        }

        [Then(@"has access to view user information")]
        public void ThenHasAccessToViewUserInformation()
        {
            throw new PendingStepException();
        }
    }
}
