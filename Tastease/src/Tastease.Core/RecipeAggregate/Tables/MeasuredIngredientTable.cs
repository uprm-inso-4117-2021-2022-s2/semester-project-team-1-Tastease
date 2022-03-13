using Tastease.SharedKernel;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.Tables;

public class MeasuredIngredientTable
{
    public int Id { get; set; }
    public string Guid { get; set; }
    public int IngredientId { get; set; }
    public IngredientTable Ingredient { get; set; }
    public int Quantity { get; set; }
    public MeasurementUnit Unit { get; set; }

}

