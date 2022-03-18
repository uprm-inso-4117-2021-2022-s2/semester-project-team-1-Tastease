using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate;

namespace Tastease.Core.Interfaces;
public interface IApplianceService
{
    public Task<Result<Appliance>> Add(Appliance appliance);
    public Task<Result<Appliance>> GetById(ApplianceId id);
}
