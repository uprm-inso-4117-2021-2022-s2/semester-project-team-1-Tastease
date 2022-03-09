using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Tastease.Core.ProjectAggregate;

public class Recipe
{
  public Recipe()
  {
    Ingredients = new HashSet<Ingredient>();
    Appliances = new HashSet<Appliance>();
    Courses = new HashSet<Course>();
    Instructions = new HashSet<Instruction>();
  }
  public TimeOnly PrepTime { get; set; }
  public TimeOnly CookTime { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public TimeOnly TotalTime => PrepTime.Add(CookTime.ToTimeSpan());
  public int Servings { get; set; }
  public ICollection<Ingredient> Ingredients { get; set; }
  public ICollection<Appliance> Appliances { get; }
  public ICollection<Course> Courses { get; set; }
  public ExecutionDifficulty ExecutionDifficulty { get; set; }
  public ICollection<Instruction> Instructions { get; set; }
  public Cuisine Cuisine { get; set; }
  public ICollection<NutritionalProperty> NutritionalProperties => Ingredients
    .SelectMany(ingredient => ingredient.NutritionalValues)
    .GroupBy(nutritionalValues => nutritionalValues.Category)
    .Select(groupedNutritionalValues => new NutritionalProperty 
    {
        Category = groupedNutritionalValues.Key,
        Value = groupedNutritionalValues.Sum(nutritionalValue => nutritionalValue.Value)
    })
    .ToList();//TODO: Memoize
}
