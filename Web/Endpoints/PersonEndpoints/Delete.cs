using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class Delete : BaseAsyncEndpoint<DeletePersonRequest, DeletePersonResponse>
    {
        private readonly IAsyncRepository<Person> _itemRepository;

        public Delete(IAsyncRepository<Person> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpDelete("api/people/{PersonId}")]
        [SwaggerOperation(
            Summary = "Delete a Person",
            Description = "Delete a Person",
            OperationId = "people.delete",
            Tags = new[] { "PersonEndpoints" })
        ]
        public override async Task<ActionResult<DeletePersonResponse>> HandleAsync([FromRoute] DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePersonResponse(request.CorrelationId());

            var itemToDelete = await _itemRepository.GetByIdAsync(request.PersonId, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok(response);
        }
    }
}