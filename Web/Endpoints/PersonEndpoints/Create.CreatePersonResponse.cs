using System;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class CreatePersonResponse : BaseResponse
    {
        public CreatePersonResponse(Guid correlationId) : base(correlationId)
        {
        }

        public PersonDto Person { get; set; }
    }
}