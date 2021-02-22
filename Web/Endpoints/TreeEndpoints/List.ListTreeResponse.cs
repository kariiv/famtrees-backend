using System;
using System.Collections.Generic;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class ListTreeResponse : BaseResponse
    {
        public ListTreeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListTreeResponse()
        {
        }

        public List<TreeDto> Trees { get; set; } = new();
    }
}
