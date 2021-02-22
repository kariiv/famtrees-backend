using System;
using System.Collections.Generic;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class ListResponse : BaseResponse
    {
        public ListResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListResponse() : base()
        {
        }

        public List<PersonParentDto> PersonParents { get; set; } = new();
    }
}