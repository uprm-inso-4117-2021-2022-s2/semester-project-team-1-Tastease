using Tastease.SharedKernel;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate;

public class MeasuredIngredient : ValueObject
{
  public MeasuredIngredient(Ingredient ingredient, int quantity, MeasurementUnit unit)
  {
    Ingredient = ingredient;
    Quantity = quantity;
    Unit = unit;
  }
  public MeasuredIngredient() { }
  public Ingredient Ingredient { get; init; }
  public int Quantity { get; init; }
  public MeasurementUnit Unit { get; init; }

}

