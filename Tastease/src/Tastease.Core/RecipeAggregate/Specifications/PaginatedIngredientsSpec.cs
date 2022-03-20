using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Tables;

namespace Tastease.Core.RecipeAggregate.Specifications
{
    public class PaginatedIngredientsSpec : Specification<IngredientTable>
    {
        public PaginatedIngredientsSpec(BasePaginationRequest pagination) 
        {
            Query.OrderBy(ingredient => ingredient.Id)
                .Skip(pagination.Page)
                .Take(pagination.Size);
        }

    }
}
