using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Tastease.SharedKernel;
using Tastease.SharedKernel.Interfaces;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate;

[StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson)]
public partial struct RecipeId { }
public class Recipe : BaseEntity<RecipeId> , IAggregateRoot
{
  public Recipe(TimeOnly prepTime,
    TimeOnly cookTime,
    string name,
    string description,
    int servings,
    ICollection<Ingredient> ingredients,
    ICollection<Appliance> appliances,
    ICollection<Course> courses,
    ExperienceLevel executionDifficulty,
    ICollection<Instruction> instructions,
    Cuisine cuisine, Cook cook)
  {
    PrepTime = prepTime;
    CookTime = cookTime;
    Name = name;
    Description = description;
    Servings = servings;
    Ingredients = ingredients;
    Appliances = appliances;
    Courses = courses;
    ExecutionDifficulty = executionDifficulty;
    Instructions = instructions;
    Cuisine = cuisine;
    Cook = cook;
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
  public ExperienceLevel ExecutionDifficulty { get; set; }
  public ICollection<Instruction> Instructions { get; set; }
  public Cook Cook { get; init; }
  public Cuisine Cuisine { get; set; }
  public ICollection<NutritionalProperty> NutritionalProperties => Ingredients
    .SelectMany(ingredient => ingredient.NutritionalValues)
    .GroupBy(nutritionalValues => nutritionalValues.Category)
    .Select(groupedNutritionalValues => new NutritionalProperty 
    {
        Category = groupedNutritionalValues.Key,
        Value = groupedNutritionalValues.Sum(nutritionalValue => nutritionalValue.Value)
    }).ToList();//TODO: Memoize
}
