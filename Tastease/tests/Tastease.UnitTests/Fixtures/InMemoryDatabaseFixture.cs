using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.Infrastructure.Data.AuthenticationContext;
using Tastease.Infrastructure.Data.CoreContext;

namespace Tastease.UnitTests.Fixtures
{
    public class InMemoryDatabaseFixture : IDisposable
    {
        public CoreDbContext CoreContext { get; private set; } = new CoreDbContext();
        public AuthenticationDbContext AuthenticationContext { get; private set; } = new AuthenticationDbContext(new DbContextOptions<AuthenticationDbContext>());
        public InMemoryDatabaseFixture()
        {
            AddRequiredData();
        }

        private void AddRequiredData()
        {
            var context = CoreContext;
            var appliances = new List<ApplianceTable>
            {
                new ApplianceTable
                {
                    Name = "Swiffer",
                    Guid = Guid.NewGuid().ToString(),
                    Description = "Expensive"
                }
            };
            context.AddRange(appliances);
            context.SaveChanges();
            var authenticationContext = AuthenticationContext;
            var users = new List<IdentityUser>
            {
            };
            context.AddRange(users);
            context.SaveChanges();

        }

        public void Dispose()
        {
            CoreContext.Dispose();
            AuthenticationContext.Dispose();
        }
    }
}
