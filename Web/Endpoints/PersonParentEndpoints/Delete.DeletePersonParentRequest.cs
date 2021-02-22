using System.ComponentModel.DataAnnotations;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class DeletePersonParentRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int PersonId { get; set; }
        [Range(1, 10000)]
        public int ParentId { get; set; }
    }
}
