using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;

public class CookTable
{
    public CookTable()
    {
      Recipes = new HashSet<RecipeTable>();
      Pantries = new HashSet<PantryTable>();
      Allergies = new HashSet<AllergyTable>();
    }
    public int Id { get; set; }
    public string Guid { get; set; }
    public string Name { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public ICollection<RecipeTable> Recipes { get; set; }
    public ICollection<PantryTable> Pantries { get; set; }
    public ICollection<AllergyTable> Allergies { get; set; }
}
