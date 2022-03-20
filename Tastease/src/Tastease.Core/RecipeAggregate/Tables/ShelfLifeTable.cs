using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;
public class ShelfLifeTable
{
  public int Id { get; set; }
  public State State { get; set; }
  public string Time { get; set; }
}

