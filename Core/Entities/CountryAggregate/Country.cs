using System.Collections.Generic;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Core.Entities.CountryAggregate
{
    class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Person> People = new();

        private Country()
        {
            // EF requirement
        }

        public Country(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
