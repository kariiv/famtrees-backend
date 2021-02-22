using System;
using System.ComponentModel.DataAnnotations;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class CreatePersonRequest : BaseRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public DateTime DeathDate { get; set; }
        [Range(0,1)]
        public Sex Sex { get; set; }
        [Range(1, 10000)]
        public int TreeId { get; set; }
    }
}