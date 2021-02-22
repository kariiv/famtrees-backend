using System;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class CreatePersonParentResponse : BaseResponse
    {
        public CreatePersonParentResponse(Guid correlationId) : base(correlationId)
        {
        }
        public string Status { get; set; } = "Added";
    }
}
