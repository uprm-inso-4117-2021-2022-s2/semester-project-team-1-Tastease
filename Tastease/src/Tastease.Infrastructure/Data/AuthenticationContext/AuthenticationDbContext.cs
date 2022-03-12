using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tastease.Infrastructure.Data.AuthenticationContext;
  public class AuthenticationDbContext : IdentityDbContext
  {
      public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
          : base(options)
      {
      }
  }
