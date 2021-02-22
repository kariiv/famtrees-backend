using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class Delete : BaseAsyncEndpoint<DeleteTreeRequest, DeleteTreeResponse>
    {
        private readonly IAsyncRepository<Tree> _itemRepository;

        public Delete(IAsyncRepository<Tree> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpDelete("api/trees/{TreeId}")]
        [SwaggerOperation(
            Summary = "Delete a Tree",
            Description = "Delete a Tree",
            OperationId = "trees.delete",
            Tags = new[] { "TreeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTreeResponse>> HandleAsync([FromRoute] DeleteTreeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTreeResponse(request.CorrelationId());

            var itemToDelete = await _itemRepository.GetByIdAsync(request.TreeId, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok(response);
        }
    }
}