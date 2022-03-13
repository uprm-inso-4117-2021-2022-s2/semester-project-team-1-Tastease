using Tastease.Core.Literals;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Extenstions;

public static class AllergyExtenstions
{
    public static Allergy ToAllergy(this AllergyTable allergy) => new Allergy
    {
        Ingredient = allergy.Ingredient.ToIngredient(),
        Serverity = allergy.Serverity
    };
}
