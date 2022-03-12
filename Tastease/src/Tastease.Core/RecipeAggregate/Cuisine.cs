using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;

public class Cuisine : ValueObject
{
  
  public Cuisine() { }
  public Cuisine(string name, string region)
  {
    Name = name;
    Region = region;
  }
  public string Name { get; init; }
  public string Region { get; init; }
}
