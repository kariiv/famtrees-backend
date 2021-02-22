using System;
using System.ComponentModel.DataAnnotations;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class UpdatePersonRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public DateTime DeathDate { get; set; }
    }
}