using System;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class UpdateTreeResponse : BaseResponse
    {
        public UpdateTreeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public TreeDto Tree { get; set; }
    }
}
