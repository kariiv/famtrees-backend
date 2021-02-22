using System;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DeathDate { get; set; }
        public Sex Sex { get; set; }
        public int TreeId { get; set; }
    }
}