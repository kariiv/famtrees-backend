using System.ComponentModel.DataAnnotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class DeleteTreeRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int TreeId { get; set; }
    }
}
