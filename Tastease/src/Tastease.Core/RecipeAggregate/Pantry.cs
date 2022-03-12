using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;

[StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson)]
public partial struct PantryId { }
public class Pantry : BaseEntity<PantryId>
{
    public Pantry(string name, Cook cook, ICollection<Appliance> appliances, ICollection<Ingredient> ingredients)
    {
      Ingredients = ingredients;
      Appliances = appliances;
      Name = name;
      Cook = cook;
    }
    public Pantry(Cook cook)
    {
      Ingredients = new HashSet<Ingredient>();
      Appliances = new HashSet<Appliance>();
      Cook = cook;
    }
    public Cook Cook { get; init; }
    public string Name { get; set; }
    public ICollection<Appliance> Appliances { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
}

