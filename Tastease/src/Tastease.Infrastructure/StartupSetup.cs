using Tastease.Infrastructure.Data.AuthenticationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Tastease.Infrastructure.Areas.Identity;
using Tastease.Infrastructure.Data;
using Tastease.Infrastructure.Data.CoreContext;

namespace Tastease.Infrastructure;

public static class StartupSetup
{
  public static void AddAuthenticationDbContexts(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<AuthenticationDbContext>(options =>
      options.UseSqlServer(connectionString));// will be created in web project root
    services.AddDatabaseDeveloperPageExceptionFilter();
    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationDbContext>();
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

  }
  public static void AddTasteaseCoreDbContexts(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<CoreDbContext>(options =>
      options.UseSqlServer(connectionString));// will be created in web project root
  }
}
