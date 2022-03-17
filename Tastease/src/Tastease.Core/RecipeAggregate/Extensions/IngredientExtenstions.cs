using Tastease.Core.RecipeAggregate.Tables;
namespace Tastease.Core.RecipeAggregate.Extenstions;

public static class IngredientExtenstions
{
    public static Ingredient ToIngredient(this IngredientTable ingredient) => new Ingredient
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        NutritionalValues = ingredient.NutritionalValues
            .Select(nutritionalProperty => nutritionalProperty.ToNutritionalProperty()),
        ShelfLives = ingredient.ShelfLives
            .Select(shelfLife => shelfLife.ToShelfLife())
    };
    public static IngredientTable ToIngredientTable(this Ingredient ingredient) => new IngredientTable
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
    };
}

