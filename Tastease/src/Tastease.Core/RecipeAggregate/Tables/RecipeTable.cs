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
    Values = new HashSet<RecipeValueTable>();
    Instructions = new HashSet<InstructionTable>();
  }
  public int Id { get; set; }
  public string Guid { get; set; }
  public string PrepTime { get; set; }
  public string CookTime { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int Servings { get; set; }
  public ICollection<IngredientTable> Ingredients { get; set; }
  public ICollection<ApplianceTable> Appliances { get; }
  public ICollection<RecipeValueTable> Values { get; set; }
  public ExperienceLevel ExecutionDifficulty { get; set; }
  public ICollection<InstructionTable> Instructions { get; set; }
  public CuisineTable Cuisine { get; set; }
  public CookTable Cook { get; set; }
}
public enum RecipeType 
{
    Course
}
public class RecipeValueTable 
{
    public int Id { get; set; }
    public string Nameof { get; set; }
    public RecipeType Type { get; set; }
    public string Value { get; set; }
    public RecipeTable Recipe { get; set; }
    public int RecipeId { get; set; }
}
