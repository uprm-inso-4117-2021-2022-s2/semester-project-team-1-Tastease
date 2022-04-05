using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Extenstions;
public static class ApplianceExtenstions
{
    public static ApplianceTable ToApplianceTable(this Appliance appliance) => new ApplianceTable
    {
        Name = appliance.Name,
        Description = appliance.Description,
        Guid = appliance.Id.ToString(),
    };
    public static Appliance ToAppliance(this ApplianceTable appliance) => new Appliance
    {
        Name = appliance.Name,
        Description = appliance.Description,
        Id = new ApplianceId(Guid.Parse(appliance.Guid))
    };
    public static Appliance ToAppliance(this AddApplianceRequest appliance) => new Appliance
    {
        Description = appliance.Description,
        Name = appliance.Name,
        Id = new ApplianceId(Guid.NewGuid())

    };
}

