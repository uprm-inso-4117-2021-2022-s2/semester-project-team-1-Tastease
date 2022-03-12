using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;

public class NutritionalProperty : ValueObject
{
  public int Value { get; init; }
  public NutritionalCategory Category { get; init; }
  public NutritionalProperty() { }
  public NutritionalProperty(int value, NutritionalCategory category)
  {
    Value = value;
    Category = category;
  }

  

}

