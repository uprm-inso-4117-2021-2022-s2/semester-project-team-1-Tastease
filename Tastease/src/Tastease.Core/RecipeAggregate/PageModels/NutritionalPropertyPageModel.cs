using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.PageModels
{
    public class NutritionalPropertyPageModel
    {
        public string Value { get; set; }
        public NutritionalCategory? Category { get; set; }
    }
}
