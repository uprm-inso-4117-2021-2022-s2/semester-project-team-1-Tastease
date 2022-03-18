﻿using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Interfaces;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Extenstions;
using Tastease.Core.RecipeAggregate.Specifications;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel.Interfaces;

namespace Tastease.Core.Services;
public class ApplianceService : IApplianceService
{
    private readonly IRepository<ApplianceTable> _repository;

    public ApplianceService(IRepository<ApplianceTable> repository)
    {
        _repository = repository;
    }
    public async Task<Result<Appliance>> Add(Appliance appliance)
    {
        var addedAppliance = await _repository.AddAsync(appliance.ToApplianceTable());
        return Result<Appliance>.Success(addedAppliance.ToAppliance());
    }

    public Task<Result<Appliance>> GetById(ApplianceId id)
    {
        return Task.FromResult(Result<Appliance>.NotFound());
    }
}
