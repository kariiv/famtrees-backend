using System.ComponentModel.DataAnnotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class GetByIdPersonRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int PersonId { get; set; }
    }
}