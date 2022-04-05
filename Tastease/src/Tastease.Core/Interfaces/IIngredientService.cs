using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.Interfaces;
public interface IIngredientService
{
    public Task<Result<Ingredient>> GetById(IngredientId ingredientId);
    public Task<Result<IEnumerable<Ingredient>>> GetAll(BasePaginationRequest pagination);
    public Task<Result<Ingredient>> Add(AddIngredientRequest ingredient);
    public Task<Result<Ingredient>> Delete(IngredientId ingredientId);

}
