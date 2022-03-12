using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;

public class AllergyTable
{
  public int Id { get; set; }
  public string Guid { get; set; }
  public Serverity Serverity { get; set; }
  public IngredientTable Ingredient { get; set; }
}
