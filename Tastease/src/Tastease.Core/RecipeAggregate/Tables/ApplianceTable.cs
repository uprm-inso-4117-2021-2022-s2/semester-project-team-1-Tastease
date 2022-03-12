using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.RecipeAggregate.Tables;
public class ApplianceTable
{
  public int Id { get; set; }
  public string Guid { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
}

