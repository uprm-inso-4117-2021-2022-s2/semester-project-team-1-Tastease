using Ardalis.GuardClauses;
using Ardalis.Result;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Extensions;
using Tastease.Core.RecipeAggregate.Extenstions;
using Tastease.Core.RecipeAggregate.Specifications;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel.Interfaces;

namespace Tastease.Core.Services;
public class IngredientService : IIngredientService
{
    private readonly IRepository<IngredientTable> _repository;
    private readonly IValidator<Ingredient> _validator;

    public IngredientService(IRepository<IngredientTable> repository, IValidator<Ingredient> validator) 
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Result<Ingredient>> Add(Ingredient ingredient)
    {
        var validationResult = _validator.Validate(ingredient);
        if (!validationResult.IsValid) 
        {
            return Result<Ingredient>
                .Invalid(validationResult.Errors
                    .Select(error => error.ToValidationError())
                    .ToList());
        }
        var result =  await _repository.AddAsync(new IngredientTable 
        {
            Name = ingredient.Name,
            Type = ingredient.Type,
        });
        return Result<Ingredient>.Success(result.ToIngredient());
    }

    public Result<Ingredient> Delete(Ingredient ingredient)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<Ingredient>>> GetAll(int page = 0, int size = 10)
    {
        if(page < 0 || size < 0) 
        {
            return Result<IEnumerable<Ingredient>>
                .Invalid(new List<ValidationError> 
                {
                    new ValidationError 
                    {
                        Severity = ValidationSeverity.Error,
                        ErrorMessage = "",
                        Identifier = nameof(page)
                    } 
                });
        }
        var query = new PaginatedIngredientsSpec(page, size);
        var ingredients = await _repository.ListAsync(query);
        if(ingredients is null) { return Result<IEnumerable<Ingredient>>.NotFound(); }

        return Result<IEnumerable<Ingredient>>
            .Success(ingredients.Select(ingredient => ingredient.ToIngredient()));

    }
}
