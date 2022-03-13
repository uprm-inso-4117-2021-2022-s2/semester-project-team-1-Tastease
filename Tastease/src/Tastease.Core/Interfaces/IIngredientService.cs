using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate;

namespace Tastease.Core.Interfaces;
public interface IIngredientService
{
    public Task<Result<IEnumerable<Ingredient>>> GetAll(int page = 0, int size = 10);
    public Task<Result<Ingredient>> Add(Ingredient ingredient);
    public Result<Ingredient> Delete(Ingredient ingredient);

}
