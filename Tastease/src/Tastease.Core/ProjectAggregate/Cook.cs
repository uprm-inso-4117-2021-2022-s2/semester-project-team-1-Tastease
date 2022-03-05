using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.SharedKernel;

namespace Tastease.Core.ProjectAggregate;

public class Cook : BaseEntity
{
    public Cook() 
    {
        Recipes = new HashSet<Recipe>();
        Pantries = new HashSet<Pantry>();
        Allergies = new HashSet<Allergy>();
    }
    public string Name { get; set; }
    public CulinarySkill CulinarySkill { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
    public ICollection<Pantry> Pantries { get; set; }
    public ICollection<Allergy> Allergies { get; set; }
}
