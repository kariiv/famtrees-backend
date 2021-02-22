using System;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class UpdatePersonResponse : BaseResponse
    {
        public UpdatePersonResponse(Guid correlationId) : base(correlationId)
        {
        }

        public PersonDto Person { get; set; }
    }
}