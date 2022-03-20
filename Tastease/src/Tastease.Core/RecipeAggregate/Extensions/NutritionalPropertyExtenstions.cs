using Tastease.Core.Literals;
using Tastease.Core.RecipeAggregate.PageModels;
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
    public static NutritionalPropertyTable ToNutritionalPropertyTable(this NutritionalProperty nutritionalProperty) => new NutritionalPropertyTable
    {
        Category = nutritionalProperty.Category,
        Value = nutritionalProperty.Value
    };
    public static NutritionalPropertyPageModel ToNutritionalPropertyPageModel(this NutritionalProperty nutritionalProperty) => new NutritionalPropertyPageModel
    {
        Category = nutritionalProperty.Category,
        Value = nutritionalProperty.Value.ToString()
    };
    public static NutritionalProperty ToNutritionalProperty(this NutritionalPropertyPageModel nutritionalProperty) => new NutritionalProperty
    {
        Category = nutritionalProperty.Category.HasValue ? nutritionalProperty.Category.Value : default,
        Value = int.TryParse(nutritionalProperty.Value, out int value) 
            ? value
            : default(int),
    };
}