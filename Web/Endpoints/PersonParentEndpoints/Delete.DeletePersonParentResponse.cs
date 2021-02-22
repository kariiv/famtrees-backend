using System;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class DeletePersonParentResponse : BaseResponse
    {
        public DeletePersonParentResponse(Guid correlationId) : base(correlationId)
        {
        }

        public string Status { get; set; } = "Removed";
    }
}
