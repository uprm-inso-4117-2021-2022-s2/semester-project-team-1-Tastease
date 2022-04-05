using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.UnitTests.Collections;
using Tastease.UnitTests.Fixtures;
using Tastease.UnitTests.PageModels;
using Xunit;

namespace Tastease.UnitTests.Web
{

    [Collection(nameof(WebTestCollection))]
    public class AuthenticationTest
    {
        private readonly WebAppFixture _webAppFixture;

        private readonly RequestGeneratorFixture _requestGeneratorFixture;
        private readonly UserCredentials _userCredentails;
        private readonly InMemoryDatabaseFixture _databaseFixture;

        public AuthenticationTest(WebAppFixture webAppFixture,
            RequestGeneratorFixture requestGeneratorFixture, 
            InMemoryDatabaseFixture databaseFixture) 
        {
            _webAppFixture = webAppFixture;
            _requestGeneratorFixture = requestGeneratorFixture;
            _databaseFixture = databaseFixture;
        }

        [Fact]
        public async Task WebApp_ShouldAddAUser_WhenSaidUserRegisters()
        {
            var userCredentails = _requestGeneratorFixture.GenerateUserCredentials();
            // Open new page
            await using var context = await _webAppFixture.GetBrowserContextAsync();
            await context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
            var page = await context.NewPageAsync();
            // Go to http://localhost:57679/
            await page.GotoAsync("http://localhost:57679/");
            // Click text=Register
            await page.RunAndWaitForNavigationAsync(async () =>
            {
                await page.Locator("text=Register").ClickAsync();
            });
            page.Url.Should().Be("http://localhost:57679/Identity/Account/Register");
            // Click input[name="Input\.Email"]
            await page.Locator("input[name=\"Input\\.Email\"]").ClickAsync();
            // Fill input[name="Input\.Email"]
            await page.Locator("input[name=\"Input\\.Email\"]").FillAsync(userCredentails.Email);
            // Click input[name="Input\.Password"]
            await page.Locator("input[name=\"Input\\.Password\"]").ClickAsync();
            // Click input[name="Input\.Password"]
            await page.Locator("input[name=\"Input\\.Password\"]").ClickAsync();
            // Fill input[name="Input\.Password"]
            await page.Locator("input[name=\"Input\\.Password\"]").FillAsync(userCredentails.Password);
            // Click input[name="Input\.ConfirmPassword"]
            await page.Locator("input[name=\"Input\\.ConfirmPassword\"]").ClickAsync();
            // Fill input[name="Input\.ConfirmPassword"]
            await page.Locator("input[name=\"Input\\.ConfirmPassword\"]").FillAsync(userCredentails.Password);
            // Click button:has-text("Register")
            await page.Locator("button:has-text(\"Register\")").ClickAsync();
            // Assert.AreEqual("http://localhost:57679/Identity/Account/RegisterConfirmation?email=BananaJams@gmail.com&returnUrl=%2F", page.Url);
            // Click text=Click here to confirm your account
            await page.Locator("text=Click here to confirm your account").ClickAsync();
            // Assert.AreEqual("http://localhost:57679/Identity/Account/ConfirmEmail?userId=bf2a4319-8961-4a97-b76e-b4b684bc0ed6&code=Q2ZESjhCUktWemJtUGR0Q201MGR5REJoQjRDMWpNTUlid0NNUjlCc2E1Qk5seU91UDg4czVLeGxIYjRHRklZcGFRMmlGVDd4NjBuazlNdUF4eU1DRVdUbExFK3NvQk5CM1hhcEpzaTh2OEpRVmZUZkwzOW5CRUJ3ZDBvMEdQdjY2bFppZVB4aG9pbktuUXZJWlY5Y2hPSHMxZWphN0tWZnhyYmZsV29ZZm9yeTRDUE5CNDg4aFBCeTRsWkNKWWU5N01UZnlLMHgyNi9zOEtnWUtFbmsyK2E2WFN5Q3VrTGFQU21SZ2F1T1pQejRRNjRUSndiZWtLQzJtVEVxd2NEWkdKSVJQdz09&returnUrl=%2F", page.Url);
            // Click a:has-text("Tastease.Web")
            await page.Locator("a:has-text(\"Tastease.Web\")").ClickAsync();
            // Assert.AreEqual("http://localhost:57679/", page.Url);
            // Click text=Log in
            await page.Locator("text=Log in").ClickAsync();
            // Assert.AreEqual("http://localhost:57679/Identity/Account/Login", page.Url);
            // Click input[name="Input\.Email"]
            await page.Locator("input[name=\"Input\\.Email\"]").ClickAsync();
            // Click input[name="Input\.Email"]
            await page.Locator("input[name=\"Input\\.Email\"]").ClickAsync();
            // Fill input[name="Input\.Email"]
            await page.Locator("input[name=\"Input\\.Email\"]").FillAsync(userCredentails.Email);
            // Click input[name="Input\.Password"]
            await page.Locator("input[name=\"Input\\.Password\"]").ClickAsync();
            // Click input[name="Input\.Password"]
            await page.Locator("input[name=\"Input\\.Password\"]").ClickAsync();
            // Fill input[name="Input\.Password"]
            await page.Locator("input[name=\"Input\\.Password\"]").FillAsync(userCredentails.Password);
            // Check input[type="checkbox"]
            await page.Locator("input[type=\"checkbox\"]").CheckAsync();
            // Click button:has-text("Log in")
            await page.Locator("button:has-text(\"Log in\")").ClickAsync();
            // Assert.AreEqual("http://localhost:57679/", page.Url);

            await context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = $"{_webAppFixture._tracePath}\\{nameof(this.WebApp_ShouldAddAUser_WhenSaidUserRegisters)}{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip"
            });
        }


    }
}
