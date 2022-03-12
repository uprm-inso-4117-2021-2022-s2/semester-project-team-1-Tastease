using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;

public class PantryTable
{
    public PantryTable()
    {
      Ingredients = new HashSet<IngredientTable>();
      Appliances = new HashSet<ApplianceTable>();
    }
    public int Id { get; set; }
    public string Guid { get; set; }
    public CookTable Cook { get; init; }
    public string Name { get; set; }
    public ICollection<ApplianceTable> Appliances { get; set; }
    public ICollection<IngredientTable> Ingredients { get; set; }
}

