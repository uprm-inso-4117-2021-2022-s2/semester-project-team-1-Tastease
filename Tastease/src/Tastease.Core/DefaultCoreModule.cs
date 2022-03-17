using Autofac;
using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate.Validators;
using Tastease.Core.Services;
using FluentValidation;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.RequestModels;

namespace Tastease.Core;

public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApplianceService>()
            .As<IApplianceService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<CookService>()
            .As<ICookService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<IngredientService>()
            .As<IIngredientService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<PantryService>()
            .As<IPantryService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<RecipeService>()
            .As<IRecipeService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<IngredientValidator>()
            .As<IValidator<Ingredient>>()
            .InstancePerLifetimeScope();
        builder.RegisterType<LiteralService>()
            .As<ILiteralService>()
            .InstancePerLifetimeScope(); 
        builder.RegisterType<NutritionalPropertyValidator>()
            .As<IValidator<NutritionalProperty>>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ShelfLifeValidator>()
            .As<IValidator<ShelfLife>>()
            .InstancePerLifetimeScope();
        builder.RegisterType<BasePaginationRequestValidator>()
            .As<IValidator<BasePaginationRequest>>()
            .InstancePerLifetimeScope();
    }
}
