using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;
[StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson)]
public partial struct CookId { }
public class Cook : BaseEntity<CookId>
{
    public Cook(string name, 
      ExperienceLevel experienceLevel,
      ICollection<Recipe> recipes,
      ICollection<Pantry> pantries, 
      ICollection<Allergy> allergies)
    {
      Name = name;
      ExperienceLevel = experienceLevel;
      Recipes = recipes;
      Pantries = pantries;
      Allergies = allergies;
    }
    public Cook()
    {
      Recipes = new HashSet<Recipe>();
      Pantries = new HashSet<Pantry>();
      Allergies = new HashSet<Allergy>();
    }
    public string Name { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
    public ICollection<Pantry> Pantries { get; set; }
    public ICollection<Allergy> Allergies { get; set; }
}
