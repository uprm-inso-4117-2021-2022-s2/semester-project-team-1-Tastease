using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Utils;
using Tastease.UnitTests.PageModels;

namespace Tastease.UnitTests.Fixtures
{
    public class WebAppFixture : IDisposable
    {
        private readonly ILookup<string, Type> _pageModelTypeLookup;
        public readonly string _basePath;
        public readonly string _tracePath;
        private bool _intialized = false;
        private IPlaywright _playwright { get; set; }
        private IBrowser _browser { get; set; }
        public WebAppFixture() 
        {
            _pageModelTypeLookup = typeof(BasePageModel).Assembly.ExportedTypes
                .Where(x => typeof(BasePageModel).IsAssignableFrom(x) 
                    && !x.IsInterface
                    && !x.IsAbstract)
                .ToLookup(x => x.Name);
            _basePath = ConfigManager.GetFromAppSettingsJson<string>("TestBasePath");
            _tracePath = ConfigManager.GetFromAppSettingsJson<string>("TestTracePath");
        }
        public async Task<T> CreatePageModel<T>() where T : BasePageModel
        {
            await ResolveDependancies();
            var pageModelType = _pageModelTypeLookup[typeof(T).Name].SingleOrDefault(x => 
                x.GetConstructors().Count() == 1
                && x.GetConstructors().Single().GetParameters().Length == 1);

            var instanciatedPageModel = (BasePageModel)Activator.CreateInstance(pageModelType, _browser);
            await instanciatedPageModel.IntializeContextAsync(_basePath, _tracePath);
            return (T)instanciatedPageModel;
        }
        public async Task<IBrowserContext> GetBrowserContextAsync() 
        {
            await ResolveDependancies();
            return await _browser.NewContextAsync();
        }
        
        public async Task ResolveDependancies() 
        {
            if (!_intialized) 
            {
                _intialized = true;
                _playwright = await Playwright.CreateAsync();
                _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    SlowMo = 1000
                });
            }
        }
        public void Dispose()
        {
            _playwright.Dispose();
            _browser.DisposeAsync();
        }
    }
}
