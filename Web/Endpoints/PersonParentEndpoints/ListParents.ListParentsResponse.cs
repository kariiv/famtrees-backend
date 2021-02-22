using System;
using System.Collections.Generic;
using FamTrees.Web.Endpoints.PersonEndpoints;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class ListParentsResponse : BaseResponse
    {
        public ListParentsResponse(Guid correlationId) : base(correlationId)
        {
        }

        public List<int> Parents { get; set; } = new();
    }
}