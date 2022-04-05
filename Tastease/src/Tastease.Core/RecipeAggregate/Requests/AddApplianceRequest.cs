using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.RecipeAggregate.Requests
{
    public class AddApplianceRequest
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
