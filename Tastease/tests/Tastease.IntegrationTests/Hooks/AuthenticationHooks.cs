using BoDi;
using Microsoft.Playwright;
using Tastease.UnitTests.PageModels;

namespace Tastease.IntegrationTests.Hooks
{
    [Binding]
    public class AuthenticationHooks
    {

        [BeforeScenario("Authentication")]
        public async Task SetupBeforeScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
            {
                SlowMo = 2000,
                Headless = true,
            });
            var pageModel = new AuthenticationPageModel(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageModel);
        }
        [AfterScenario]
        public async void SetupAfterScenario(IObjectContainer container) 
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            playwright.Dispose();
        }
    }
}
