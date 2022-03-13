using Tastease.Core.Literals;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;
public class ShelfLifeTable
{
  public ShelfLifeTable() 
  {
    Values = new HashSet<ShelfLifeValueTable>();
  }
  public int Id { get; set; }
  public string Guid { get; set; }
  public State State { get; set; }
  public ICollection<ShelfLifeValueTable> Values { get; set; }
}
public enum ShelfLifeValueType 
{
    Time
}
public class ShelfLifeValueTable 
{
    public string Value { get; set; }
    public int Id { get; set; }
    public string Nameof { get; set; }
    public ShelfLifeValueType Type { get; set; }
    public ShelfLifeTable ShelfLife { get; set; }
    public int ShelfLifeId { get; set; }

}

