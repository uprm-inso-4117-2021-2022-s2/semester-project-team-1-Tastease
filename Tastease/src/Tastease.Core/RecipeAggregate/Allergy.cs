using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;

public class Allergy : ValueObject
{
  public Allergy() { }
  public Allergy(Serverity serverity, Ingredient ingredient)
  {
    Serverity = serverity;
    Ingredient = ingredient;
  }
  public Serverity Serverity { get; init; }

  public Ingredient Ingredient { get; init; }
}
