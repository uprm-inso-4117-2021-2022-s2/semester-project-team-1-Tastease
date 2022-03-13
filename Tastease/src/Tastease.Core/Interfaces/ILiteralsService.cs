using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Literals;

namespace Tastease.Core.Interfaces
{
    public interface ILiteralService
    {
        IEnumerable<Course> GetCourses();
        IEnumerable<ExperienceLevel> GetExperienceLevels();
        IEnumerable<IngredientType> GetIngredientTypes();
        IEnumerable<MeasurementUnit> GetMeasurementUnits();
        IEnumerable<NutritionalCategory> GetNutritionalCategories();
        IEnumerable<Serverity> GetServerities();
        IEnumerable<State> GetStates();
    }
}
