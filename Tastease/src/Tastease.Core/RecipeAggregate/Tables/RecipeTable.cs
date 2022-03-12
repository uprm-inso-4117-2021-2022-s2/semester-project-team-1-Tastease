using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Tastease.SharedKernel;
using Tastease.SharedKernel.Interfaces;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.Tables;
public class RecipeTable
{
  public RecipeTable()
  {
    Ingredients = new HashSet<IngredientTable>();
    Appliances = new HashSet<ApplianceTable>();
    Courses = new HashSet<Course>();
    Instructions = new HashSet<InstructionTable>();
  }
  public int Id { get; set; }
  public string Guid { get; set; }
  public TimeOnly PrepTime { get; set; }
  public TimeOnly CookTime { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int Servings { get; set; }
  public ICollection<IngredientTable> Ingredients { get; set; }
  public ICollection<ApplianceTable> Appliances { get; }
  public ICollection<Course> Courses { get; set; }
  public ExperienceLevel ExecutionDifficulty { get; set; }
  public ICollection<InstructionTable> Instructions { get; set; }
  public CuisineTable Cuisine { get; set; }
  public CookTable Cook { get; set; }
}
