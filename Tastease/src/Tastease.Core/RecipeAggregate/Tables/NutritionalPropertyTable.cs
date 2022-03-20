using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;

public class NutritionalPropertyTable
{
  public int Id { get; set; }
  public int Value { get; init; }
  public NutritionalCategory Category { get; init; }
}

