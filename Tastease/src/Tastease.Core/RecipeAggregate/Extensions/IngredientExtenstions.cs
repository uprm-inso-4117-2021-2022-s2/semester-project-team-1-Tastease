using Tastease.Core.RecipeAggregate.PageModels;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Tables;
namespace Tastease.Core.RecipeAggregate.Extenstions;

public static class IngredientExtenstions
{
    public static Ingredient ToIngredient(this IngredientTable ingredient) => new Ingredient
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        Id = new IngredientId(Guid.Parse(ingredient.Guid)),
        NutritionalValues = ingredient.NutritionalValues
            .Select(nutritionalProperty => nutritionalProperty.ToNutritionalProperty()),
        ShelfLives = ingredient.ShelfLives
            .Select(shelfLife => shelfLife.ToShelfLife())
    };
    public static Ingredient ToIngredient(this AddIngredientRequest ingredient) => new Ingredient
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        Id = new IngredientId(Guid.NewGuid()),
        NutritionalValues = ingredient.NutritionalValues,
        ShelfLives = ingredient.ShelfLives
    };
    public static IngredientTable ToIngredientTable(this Ingredient ingredient) => new IngredientTable
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        Guid = ingredient.Id.ToString(),
        NutritionalValues = ingredient.NutritionalValues
            .Select(nutritionalProperty => nutritionalProperty.ToNutritionalPropertyTable())
            .ToList(),
        ShelfLives = ingredient.ShelfLives
            .Select(shelfLife => shelfLife.ToShelfLifeTable())
            .ToList()
    };
    public static IngredientPageModel ToIngredientPageModel(this Ingredient ingredient) => new IngredientPageModel
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        Id = ingredient.Id,
        ShelfLives = ingredient.ShelfLives
            .Select(shelfLife => shelfLife.ToShelfLifePageModel())
            .ToList(),
        NutritionalValues = ingredient.NutritionalValues
            .Select(nutritionalProperty => nutritionalProperty.ToNutritionalPropertyPageModel())
            .ToList()
    };
    public static AddIngredientRequest ToAddIngredientRequest(this IngredientPageModel ingredient) => new AddIngredientRequest
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        ShelfLives = ingredient.ShelfLives
            .Select(shelfLife => shelfLife.ToShelfLife())
            .ToList(),
        NutritionalValues = ingredient.NutritionalValues
            .Select(nutritionalProperty => nutritionalProperty.ToNutritionalProperty())
            .ToList()
    };
    public static Ingredient ToIngredient(this IngredientPageModel ingredient) => new Ingredient
    {
        Name = ingredient.Name,
        Type = ingredient.Type,
        Id = ingredient.Id,
        ShelfLives = ingredient.ShelfLives
            .Select(shelfLife => shelfLife.ToShelfLife())
            .ToList(),
        NutritionalValues = ingredient.NutritionalValues
            .Select(nutritionalProperty => nutritionalProperty.ToNutritionalProperty())
            .ToList()
    };
}

