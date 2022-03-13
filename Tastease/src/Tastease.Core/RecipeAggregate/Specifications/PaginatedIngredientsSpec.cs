using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Tables;

namespace Tastease.Core.RecipeAggregate.Specifications
{
    public class PaginatedIngredientsSpec : Specification<IngredientTable>
    {
        public PaginatedIngredientsSpec(int page = 0, int size= 10) 
        {
            Query.OrderBy(ingredient => ingredient.Id)
                .Skip(page)
                .Take(size);
        }

    }
}
