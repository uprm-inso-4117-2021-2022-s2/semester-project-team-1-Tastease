using Tastease.SharedKernel;

namespace Tastease.Core.ProjectAggregate;

public class Allergy : BaseEntity
{
  public Serverity Serverity { get; set; }
  public Ingredient Ingredient { get; set; }
}
