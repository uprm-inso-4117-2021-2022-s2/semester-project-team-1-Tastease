using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.ProjectAggregate;
public class ShelfLife
{
  public State State { get; set; }
  public ICollection<TimeOnly> Times { get; set; }
}
public enum State 
{
  Frozen, Refrigerated, Ambient 
}
