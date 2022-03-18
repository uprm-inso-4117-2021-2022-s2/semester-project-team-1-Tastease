using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.Core.Services;
using Tastease.Infrastructure.Data;
using Tastease.Infrastructure.Data.CoreContext;
using Xunit;

namespace Tastease.UnitTests.Core
{
    
    public class ServicesFixture : IDisposable
    {
        public readonly ILiteralService LiteralService;
        //public readonly IRecipeService RecipeService;
        //public readonly IPantryService PantryService;
        //public readonly IIngredientService IngredientService;
        //public readonly ICookService CookService;
        public readonly IApplianceService ApplianceService;
        public ServicesFixture() 
        {
            LiteralService = new LiteralService();
            ApplianceService = new ApplianceService(new EfRepository<ApplianceTable>(new CoreDbContext()));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    [CollectionDefinition(nameof(TestCollection))]
    public class TestCollection : ICollectionFixture<ServicesFixture> { }
}
