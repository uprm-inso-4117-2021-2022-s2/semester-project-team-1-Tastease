using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.Services;
public class CookService : ICookService
{
    public Task<Result<Ingredient>> Add(AddCookRequest ingredient)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Ingredient>> Delete(IngredientId ingredientId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Cook>> GetById(CookId id)
    {
        throw new NotImplementedException();
    }
}
