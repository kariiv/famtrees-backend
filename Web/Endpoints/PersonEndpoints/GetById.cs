using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class GetById : BaseAsyncEndpoint<GetByIdPersonRequest, GetByIdPersonResponse>
    {
        private readonly IAsyncRepository<Person> _itemRepository;

        public GetById(IAsyncRepository<Person> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("api/people/{PersonId}")]
        [SwaggerOperation(
            Summary = "Get a Person by Id",
            Description = "Get a Person by Id",
            OperationId = "people.get-by-id",
            Tags = new[] { "PersonEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPersonResponse>> HandleAsync([FromRoute] GetByIdPersonRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdPersonResponse(request.CorrelationId());

            var getById = await _itemRepository.GetByIdAsync(request.PersonId, cancellationToken);
            if (getById is null) return NotFound();

            var dto = new PersonDto
            {
                Id = getById.Id,
                FirstName = getById.FirstName,
                LastName = getById.LastName,
                Birthday = getById.Birthday,
                DeathDate = getById.DeathDate,
                Sex = getById.Sex
            };
            response.Person = dto;
            return response;
        }
    }
}