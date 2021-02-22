using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class DeleteTreeResponse : BaseResponse
    {
        public DeleteTreeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}
