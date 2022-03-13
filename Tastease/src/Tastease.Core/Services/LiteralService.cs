using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.Core.Interfaces;
using Tastease.Core.Literals;

namespace Tastease.Core.Services
{
    public class LiteralService : ILiteralService
    {
        private readonly Course[] _courses;
        private readonly ExperienceLevel[] _experienceLevels;
        private readonly IngredientType[] _ingredientTypes;
        private readonly MeasurementUnit[] _measurementUnits;
        private readonly NutritionalCategory[] _nutritionalCategories;
        private readonly Serverity[] _serverities;
        private readonly State[] _states;

        public LiteralService() 
        {
            _courses = Enum.GetValues<Course>();
            _experienceLevels = Enum.GetValues<ExperienceLevel>();
            _ingredientTypes = Enum.GetValues<IngredientType>();
            _measurementUnits = Enum.GetValues<MeasurementUnit>();
            _nutritionalCategories = Enum.GetValues<NutritionalCategory>();
            _serverities = Enum.GetValues<Serverity>();
            _states = Enum.GetValues<State>();
        }

        public IEnumerable<Course> GetCourses() => _courses;

        public IEnumerable<ExperienceLevel> GetExperienceLevels() => _experienceLevels;

        public IEnumerable<IngredientType> GetIngredientTypes() => _ingredientTypes;

        public IEnumerable<MeasurementUnit> GetMeasurementUnits() => _measurementUnits;

        public IEnumerable<NutritionalCategory> GetNutritionalCategories() => _nutritionalCategories;

        public IEnumerable<Serverity> GetServerities() => _serverities;

        public IEnumerable<State> GetStates() => _states;
    }
}
