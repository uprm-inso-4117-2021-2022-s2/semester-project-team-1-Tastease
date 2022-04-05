using Microsoft.Playwright;
using Tastease.Web;

namespace Tastease.UnitTests.PageModels
{
    public class AuthenticationPageModel : BasePageModel
    {
        public AuthenticationPageModel(IBrowser browser)
        {
            Browser = browser;
        }
        public override string PagePath => PageURL.Home;
        public override IPage Page { get; set; }
        public override IBrowser Browser { get; }
        public override string TraceFileName => $"{nameof(AuthenticationPageModel)}Test{DateTime.Now.ToString("yyyyMMddHHmmss")}";
    }
}
