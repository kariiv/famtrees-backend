using System;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class DeletePersonResponse : BaseResponse
    {
        public DeletePersonResponse(Guid correlationId) : base(correlationId)
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}