using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.Core.RecipeAggregate.Validators;
using Tastease.Core.Services;
using Tastease.Infrastructure.Data;
using Tastease.Infrastructure.Data.CoreContext;

namespace Tastease.UnitTests.Fixtures
{
    public class ServicesFixture : IDisposable
    {
        public readonly ILiteralService LiteralService;
        public readonly IRecipeService RecipeService;
        public readonly IPantryService PantryService;
        public readonly IIngredientService IngredientService;
        public readonly ICookService CookService;
        public readonly IApplianceService ApplianceService;
        public ServicesFixture()
        {
            LiteralService = new LiteralService();
            ApplianceService = new ApplianceService(new EfRepository<ApplianceTable>(new CoreDbContext()), new AddApplianceRequestValidator(), new BasePaginationRequestValidator());
            RecipeService = new RecipeService();
            PantryService = new PantryService(new EfRepository<ApplianceTable>(new CoreDbContext()));
            CookService = new CookService();
            IngredientService = new IngredientService(
                new EfRepository<IngredientTable>(new CoreDbContext()),
                new IngredientValidator(),
                new AddIngredientRequestValidator(),
                new BasePaginationRequestValidator());

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}