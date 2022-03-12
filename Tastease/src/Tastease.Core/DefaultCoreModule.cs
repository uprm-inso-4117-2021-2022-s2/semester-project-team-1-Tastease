using Autofac;
using Tastease.Core.Interfaces;
using Tastease.Core.Services;

namespace Tastease.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ApplianceService>()
        .As<IApplianceService>().InstancePerLifetimeScope();
    builder.RegisterType<CookService>()
        .As<ICookService>().InstancePerLifetimeScope();
    builder.RegisterType<IngredientService>()
        .As<IIngredientService>().InstancePerLifetimeScope();
    builder.RegisterType<PantryService>()
        .As<IPantryService>().InstancePerLifetimeScope();
    builder.RegisterType<RecipeService>()
        .As<IRecipeService>().InstancePerLifetimeScope();
  }
}
