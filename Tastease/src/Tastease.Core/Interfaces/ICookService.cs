using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.Interfaces;
public interface ICookService
{
    public Task<Result<Cook>> GetById(CookId id);
    public Task<Result<Ingredient>> Add(AddCookRequest ingredient);
    public Task<Result<Ingredient>> Delete(IngredientId ingredientId);
}
