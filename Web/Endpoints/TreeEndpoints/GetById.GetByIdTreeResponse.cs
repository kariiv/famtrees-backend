using System;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class GetByIdTreeResponse : BaseResponse
    {
        public GetByIdTreeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public TreeDto Tree { get; set; }
    }
}