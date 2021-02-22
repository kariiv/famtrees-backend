using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class Update : BaseAsyncEndpoint<UpdatePersonRequest, UpdatePersonResponse>
    {
        private readonly IAsyncRepository<Person> _itemRepository;

        public Update(IAsyncRepository<Person> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPut("api/people")]
        [SwaggerOperation(
            Summary = "Updates a Person",
            Description = "Updates a Person",
            OperationId = "people.update",
            Tags = new[] { "PersonEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePersonResponse>> HandleAsync(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePersonResponse(request.CorrelationId());

            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingItem is null) return NotFound();

            existingItem.UpdateDetails(request.FirstName, request.LastName, request.Birthday, request.DeathDate);
            
            await _itemRepository.UpdateAsync(existingItem, cancellationToken);

            var dto = new PersonDto
            {
                Id = existingItem.Id,
                FirstName = existingItem.FirstName,
                LastName = existingItem.LastName,
                Birthday = existingItem.Birthday,
                DeathDate = existingItem.DeathDate,
                Sex = existingItem.Sex
            };
            response.Person = dto;
            return response;
        }
    }
}