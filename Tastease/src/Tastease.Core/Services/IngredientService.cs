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
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Specifications;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel.Interfaces;

namespace Tastease.Core.Services;
public class IngredientService : IIngredientService
{
    private readonly IRepository<IngredientTable> _repository;
    private readonly IValidator<Ingredient> _validator;
    private readonly IValidator<BasePaginationRequest> _requestValidator;
    private readonly IValidator<AddIngredientRequest> _addIngredientRequestValidator;

    public IngredientService(IRepository<IngredientTable> repository,
        IValidator<Ingredient> validator,
        IValidator<AddIngredientRequest> addIngredientRequestValidator,
        IValidator<BasePaginationRequest> requestValidator) 
    {
        _repository = repository;
        _validator = validator;
        _requestValidator = requestValidator;
        _addIngredientRequestValidator = addIngredientRequestValidator;
    }

    public async Task<Result<Ingredient>> Add(AddIngredientRequest ingredient)
    {
        var validationResult = _addIngredientRequestValidator.Validate(ingredient);
        if (!validationResult.IsValid)
        {
            return Result<Ingredient>
                .Invalid(validationResult.Errors
                    .Select(error => error.ToValidationError())
                    .ToList());
        }
        var result =  await _repository.AddAsync(ingredient.ToIngredient().ToIngredientTable());
        return Result<Ingredient>.Success(result.ToIngredient());
    }

    public Result<Ingredient> Delete(Ingredient ingredient)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<Ingredient>>> GetAll(BasePaginationRequest request)
    {
        var validationResult = _requestValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<IEnumerable<Ingredient>>
                .Invalid(validationResult.Errors
                    .Select(error => error.ToValidationError())
                    .ToList());
        }
        var query = new PaginatedIngredientsSpec(request);
        var ingredients = await _repository.ListAsync(query);
        if(ingredients is null) { return Result<IEnumerable<Ingredient>>.NotFound(); }
        return Result<IEnumerable<Ingredient>>
            .Success(ingredients.Select(ingredient => ingredient.ToIngredient()));

    }



}
