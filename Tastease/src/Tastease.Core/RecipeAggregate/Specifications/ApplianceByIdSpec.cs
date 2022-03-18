using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Tables;

namespace Tastease.Core.RecipeAggregate.Specifications
{
    public class ApplianceByIdSpec : Specification<ApplianceTable>
    {
        public ApplianceByIdSpec(ApplianceId id)
        {
            Query.Where(appliance => appliance.Guid == id.ToString());
        }
    }
}
