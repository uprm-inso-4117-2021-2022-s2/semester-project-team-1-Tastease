using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Requests;

namespace Tastease.Core.Interfaces;
public interface IApplianceService
{
    public Task<Result<IEnumerable<Appliance>>> GetAll(BasePaginationRequest pagination);
    public Task<Result<Appliance>> Delete(ApplianceId id);
    public Task<Result<Appliance>> Add(AddApplianceRequest appliance);
    public Task<Result<Appliance>> GetById(ApplianceId id);
}
