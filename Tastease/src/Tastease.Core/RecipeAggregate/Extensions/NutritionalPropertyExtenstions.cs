using Tastease.Core.Literals;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Extenstions;

public static class NutritionalPropertyExtenstions
{
    public static NutritionalProperty ToNutritionalProperty(this NutritionalPropertyTable nutritionalProperty) => new NutritionalProperty
    {
        Category = nutritionalProperty.Category,
        Value = nutritionalProperty.Value
    };
}