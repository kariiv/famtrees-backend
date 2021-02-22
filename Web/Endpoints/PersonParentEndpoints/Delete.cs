using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using FamTrees.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class Delete : BaseAsyncEndpoint<DeletePersonParentRequest, DeletePersonParentResponse>
    {
        private readonly IAsyncRepository<PersonParent> _itemRepository;

        public Delete(IAsyncRepository<PersonParent> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpDelete("api/person-parent")]
        [SwaggerOperation(
            Summary = "Delete a Parent from Person",
            Description = "Delete a Parent from Person",
            OperationId = "person-parent.delete",
            Tags = new[] { "PersonParentEndpoints" })
        ]
        public override async Task<ActionResult<DeletePersonParentResponse>> HandleAsync(DeletePersonParentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePersonParentResponse(request.CorrelationId());

            var spec = new PersonParentSpecification(request.PersonId, request.ParentId);
            var items = await _itemRepository.ListAsync(spec, cancellationToken);

            if (items.Count == 0)
            {
                return NotFound();
            }

            await _itemRepository.DeleteAsync(items[0], cancellationToken);
            
            return response;
        }
    }
}