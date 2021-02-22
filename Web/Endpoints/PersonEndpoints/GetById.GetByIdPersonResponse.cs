using System;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class GetByIdPersonResponse : BaseResponse
    {
        public GetByIdPersonResponse(Guid correlationId) : base(correlationId)
        {
        }

        public PersonDto Person { get; set; }
    }
}