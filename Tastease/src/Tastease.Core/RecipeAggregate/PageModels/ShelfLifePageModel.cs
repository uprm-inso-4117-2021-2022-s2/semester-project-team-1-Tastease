using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.RecipeAggregate.PageModels
{
    public class ShelfLifePageModel
    {
        public State? State { get; set; }
        public string TimeAsString { get; set; }

        public bool Time(out TimeSpan outTime)
        {
            if(TimeSpan.TryParse(TimeAsString, out TimeSpan time)) 
            {
                outTime = time;
                return true;
            }
            outTime = default;
            return false;
        }
    }
}
