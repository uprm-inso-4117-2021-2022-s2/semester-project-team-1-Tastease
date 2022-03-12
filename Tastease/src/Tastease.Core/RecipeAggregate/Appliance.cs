using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;
public class Appliance : ValueObject
{
  public Appliance() { }
  public Appliance(string name, string description)
  {
    Name = name;
    Description = description;
  }
  public string Name { get; init; }
  public string Description { get; init; }
}

