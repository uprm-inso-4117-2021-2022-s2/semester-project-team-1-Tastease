using Tastease.Core.RecipeAggregate.PageModels;

namespace Tastease.Web;

public static class PageURL
{
    public const string Ingredients = "./ingredients", ManyCooks = "./cooks", Home ="./" ;
    public static string IndividualCook(CookPageModel cook) => $"./cooks/{cook.Slug}";
}
