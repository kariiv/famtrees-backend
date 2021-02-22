using System.ComponentModel.DataAnnotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class NewTreeRequest : BaseRequest
    {
        [Required]
        public string Name { get; set; }
    }
}