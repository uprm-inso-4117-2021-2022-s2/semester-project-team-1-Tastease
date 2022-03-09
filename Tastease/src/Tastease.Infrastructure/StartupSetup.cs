using Tastease.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Tastease.Infrastructure.Areas.Identity;

namespace Tastease.Infrastructure;

public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString) =>
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(connectionString)); // will be created in web project root
  public static void AddTasteaseDbContext(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(connectionString));
    services.AddDatabaseDeveloperPageExceptionFilter();
    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

  } // will be created in web project root
}
