using System.Collections.Generic;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class ListPersonResponse : BaseResponse
    {
        public List<PersonDto> People { get; set; } = new();
    }
}