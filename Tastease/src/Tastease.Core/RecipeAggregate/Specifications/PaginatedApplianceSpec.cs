using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Tables;

namespace Tastease.Core.RecipeAggregate.Specifications
{
    public class PaginatedApplianceSpec : Specification<ApplianceTable>
    {
        public PaginatedApplianceSpec(BasePaginationRequest pagination)
        {
            Query.OrderBy(appliance => appliance.Id)
                .Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size);
        }

    }
}
