using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;

public class CuisineTable
{
  public int Id { get; set; }
  public string Guid { get; set; }
  public string Name { get; set; }
  public string Region { get; set; }
}
