using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Tables;

namespace Tastease.Core.RecipeAggregate.Specifications
{
    public class RecipeNotContainingSpec : Specification<RecipeTable>
    {
        public RecipeNotContainingSpec(IEnumerable<AllergyTable>  allergies) 
        {

            Query.Where(recipe => 
                !recipe.Ingredients.Any(ingredient => 
                    allergies.Select(allergy => 
                        allergy.Ingredient.Guid).Contains(ingredient.Guid)));
        }
    }
}
