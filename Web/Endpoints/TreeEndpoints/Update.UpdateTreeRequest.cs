using System.ComponentModel.DataAnnotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class UpdateTreeRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}