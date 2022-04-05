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
public class ApplianceService : IApplianceService
{
    private readonly IRepository<ApplianceTable> _repository;
    private readonly IValidator<AddApplianceRequest> _validator;
    private readonly IValidator<BasePaginationRequest> _requestValidator;

    public ApplianceService(IRepository<ApplianceTable> repository,
        IValidator<AddApplianceRequest> validator,
        IValidator<BasePaginationRequest> requestValidator)
    {
        _repository = repository;
        _validator = validator;
        _requestValidator = requestValidator;
    }

    public async Task<Result<Appliance>> Add(AddApplianceRequest appliance)
    {
        var validationResult = _validator.Validate(appliance);
        if (!validationResult.IsValid) 
        {
            return Result<Appliance>.Invalid(
                    validationResult.Errors.Select(error => 
                        error.ToValidationError())
                .ToList());
        }
        var addedAppliance = await _repository.AddAsync(appliance.ToAppliance().ToApplianceTable());
        return Result<Appliance>.Success(addedAppliance.ToAppliance());
    }

    public async Task<Result<Appliance>> Delete(ApplianceId id)
    {
        var query = new ApplianceByIdSpec(id);
        var appliances = await _repository.ListAsync(query);
        if (appliances is null || !appliances.Any()) { return Result<Appliance>.NotFound(); }
        var applianceToDelete = appliances.First();
        await _repository.DeleteAsync(applianceToDelete);
        return Result<Appliance>.Success(applianceToDelete.ToAppliance());
    }

    public async Task<Result<IEnumerable<Appliance>>> GetAll(BasePaginationRequest pagination)
    {
        var validationResult = _requestValidator.Validate(pagination);
        if (!validationResult.IsValid)
        {
            return Result<IEnumerable<Appliance>>.Invalid(
                    validationResult.Errors.Select(error =>
                        error.ToValidationError())
                .ToList());
        }
        var query = new PaginatedApplianceSpec(pagination);
        var appliances = await _repository.ListAsync(query);
        if (appliances is null) { return Result<IEnumerable<Appliance>>.NotFound(); }

        return Result<IEnumerable<Appliance>>.Success(appliances
            .Select(appliance => appliance.ToAppliance())
            .ToList());
    }

    public async Task<Result<Appliance>> GetById(ApplianceId id)
    {
        var query = new ApplianceByIdSpec(id);
        var appliances = await _repository.ListAsync(query);
        if(appliances is null || !appliances.Any()) { return Result<Appliance>.NotFound(); }

        return Result<Appliance>.Success(appliances.First().ToAppliance());
    }
}
