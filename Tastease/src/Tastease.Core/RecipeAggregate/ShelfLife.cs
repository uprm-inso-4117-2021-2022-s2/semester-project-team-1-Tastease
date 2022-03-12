using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;
public class ShelfLife : ValueObject
{
  public State State { get; init; }
  public ICollection<TimeOnly> Times { get; init; }
}
