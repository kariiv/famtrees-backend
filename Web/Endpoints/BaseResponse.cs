using System;

namespace FamTrees.Web.Endpoints
{
    /// <summary>
    /// Base class used by API responses
    /// </summary>
    public abstract class BaseResponse : BaseMessage
    {
        public BaseResponse(Guid correlationId)
        {
            _correlationId = correlationId;
        }
        public BaseResponse()
        {
        }
    }
}
