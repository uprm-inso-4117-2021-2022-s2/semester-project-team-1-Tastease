using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;
public class ShelfLifeTable
{
  public ShelfLifeTable() 
  {
    Times = new HashSet<TimeOnly>();
  }
  public int Id { get; set; }
  public string Guid { get; set; }
  public State State { get; set; }
  public ICollection<TimeOnly> Times { get; set; }
}

