using System;
using System.Collections.Generic;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class ListFromTreeResponse : BaseResponse
    {
        public ListFromTreeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListFromTreeResponse()
        {
        }

        public List<PersonDto> People { get; set; } = new();
    }
}