using System;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class NewTreeResponse : BaseResponse
    {

        public NewTreeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public TreeDto Tree { get; set; }
    }
}
