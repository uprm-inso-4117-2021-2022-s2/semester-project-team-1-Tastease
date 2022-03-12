
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate;
public class Instruction : ValueObject
{
  public Instruction(string step,
    int number,
    ICollection<string> adjustment,
    Appliance? appliance= null,
    ICollection<MeasuredIngredient>? measuredIngredients = null) 
  {
    Step = step;
    Number = number;
    Adjustments = adjustment;
    Appliance = appliance;
    MeasuredIngredients = measuredIngredients;
  }
  public string Step { get; init; }
  public int Number { get; init; }
  public ICollection<string> Adjustments { get; init; }
  public Appliance? Appliance { get; init; } 
  public ICollection<MeasuredIngredient>? MeasuredIngredients { get; init; }

}

