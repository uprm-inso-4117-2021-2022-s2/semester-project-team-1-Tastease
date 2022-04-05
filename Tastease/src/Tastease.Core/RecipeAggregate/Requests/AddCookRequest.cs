using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.Requests
{
    public class AddCookRequest
    {
        public string Name { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public ClaimsPrincipal User { get; set; }
    }
}
