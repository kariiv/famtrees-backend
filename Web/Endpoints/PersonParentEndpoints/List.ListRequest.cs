using System.ComponentModel.DataAnnotations;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class ListRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int TreeId { get; set; }
    }
}
