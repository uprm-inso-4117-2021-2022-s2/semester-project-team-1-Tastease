using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Tastease.Core;
using Tastease.Infrastructure;
using Tastease.Infrastructure.Data;
using Tastease.Web;
using Microsoft.OpenApi.Models;
using Radzen;
using Microsoft.EntityFrameworkCore;
using Tastease.Infrastructure.Data.AuthenticationContext;
using Tastease.Infrastructure.Data.CoreContext;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthenticationDbContexts(builder.Configuration.GetConnectionString("TasteaseAuthenticationConnection"));
//builder.Services.AddAuthenticationDbContexts(builder.Configuration.GetConnectionString("TasteaseCoreConnection"));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});


builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
  //app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Error");
  app.UseHsts();
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => 
{
  endpoints.MapControllers();
  endpoints.MapBlazorHub();
  endpoints.MapFallbackToPage("/_Host");
  
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var tasteaseAuthenticationContext = services.GetRequiredService<AuthenticationDbContext>();
    //var tasteaseCoreContext = services.GetRequiredService<CoreDbContext>();
    tasteaseAuthenticationContext.Database.Migrate();
    //tasteaseCoreContext.Database.Migrate();
    SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB.");
  }
}

app.Run();
