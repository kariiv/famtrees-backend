using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class Create : BaseAsyncEndpoint<CreatePersonParentRequest, CreatePersonParentResponse>
    {
        private readonly IFamilyTreeService _familyTreeService;
        private readonly IAppLogger<Create> _logger;

        public Create(IFamilyTreeService familyTreeService, IAppLogger<Create> logger)
        {
            _familyTreeService = familyTreeService;
            _logger = logger;
        }

        [HttpPost("api/person-parents")]
        [SwaggerOperation(
            Summary = "Add a Parent to a Person",
            Description = "Add a Parent to a Person",
            OperationId = "person-parent.create",
            Tags = new[] { "PersonParentEndpoints" })
        ]
        public override async Task<ActionResult<CreatePersonParentResponse>> HandleAsync(CreatePersonParentRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePersonParentResponse(request.CorrelationId());

            try
            {
                await _familyTreeService.AddParentForPerson(request.PersonId, request.ParentId);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                response.Status = "Error";
            }

            return response;
        }
    }
}