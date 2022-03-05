
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.ProjectAggregate;
public class Instruction
{
  public string Step { get; set; }
  public int Number { get; set; }
  public ICollection<string> Adjustment { get; set; }
  public Appliance? Appliance { get; set; } 
  public ICollection<MeasuredIngredient>? MeasuredIngredients { get; set; }

}

