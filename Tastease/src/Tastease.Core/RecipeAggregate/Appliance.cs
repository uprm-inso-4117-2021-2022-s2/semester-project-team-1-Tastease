using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;
[StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson)]
public partial struct ApplianceId { }
public class Appliance : ValueObject
{
    public Appliance() { }
    public Appliance(string name, string description, ApplianceId id)
    {
        Name = name;
        Description = description;
        Id = id;
    }
    public string Name { get; init; }
    public string Description { get; init; }
    public ApplianceId Id { get; init; }
}

