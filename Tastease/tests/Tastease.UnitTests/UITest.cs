using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tastease.UnitTests
{
    public class UITest
    {
        [Fact]
        public async Task MovingFromHomeToIngrediantAndAddint() 
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 2000
            });
            var context = await browser.NewContextAsync();
            // Open new page
            var page = await context.NewPageAsync();
            // Go to http://localhost:57679/
            await page.GotoAsync("http://localhost:57679/");
            // Click text=home Recipes keyboard_arrow_down
            await page.Locator("text=home Recipes keyboard_arrow_down").ClickAsync();
            // Click text=Ingredients
            await page.Locator("text=Ingredients").ClickAsync();
            // Assert.AreEqual("http://localhost:57679/ingredients", page.Url);
            // Click [placeholder="Name\.\.\."]
            await page.Locator("[placeholder=\"Name\\.\\.\\.\"]").ClickAsync();
            // Fill [placeholder="Name\.\.\."]
            await page.Locator("[placeholder=\"Name\\.\\.\\.\"]").FillAsync("LOLOLOL");
            // Click text=save Save
            await page.Locator("text=save Save").ClickAsync();
        }
    }
}
