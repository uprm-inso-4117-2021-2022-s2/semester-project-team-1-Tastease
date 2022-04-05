using Microsoft.Playwright;
using System.Configuration;
using Tastease.Core.Utils;
using Tastease.Web;

namespace Tastease.UnitTests.PageModels
{
    public abstract class BasePageModel : IAsyncDisposable
    {
        private string FileSaveBasePath;
        private string BasePagePath;
        public virtual string PagePath => PageURL.Home;
        public string FullPagePath(string pagePath) => $"{BasePagePath}{pagePath}";
        public abstract IPage Page { get; set; }
        public abstract IBrowser Browser { get; }
        private IBrowserContext Context { get; set; }
        public abstract string TraceFileName { get; } 
        public async Task IntializeContextAsync(string basePagePath, string fileSaveBasePath) 
        {
            BasePagePath = basePagePath;
            FileSaveBasePath = fileSaveBasePath;
            Context = await Browser.NewContextAsync();
            await Context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
            Page = await Context.NewPageAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await Context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = $"{FileSaveBasePath}\\{TraceFileName}.zip"
            });
            await Context.DisposeAsync();
        }

    }
}
