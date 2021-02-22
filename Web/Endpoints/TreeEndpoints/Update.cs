using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class Update : BaseAsyncEndpoint<UpdateTreeRequest, UpdateTreeResponse>
    {
        private readonly IAsyncRepository<Tree> _itemRepository;

        public Update(IAsyncRepository<Tree> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPut("api/trees")]
        [SwaggerOperation(
            Summary = "Updates a Tree",
            Description = "Updates a Tree",
            OperationId = "trees.update",
            Tags = new[] { "TreeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTreeResponse>> HandleAsync(UpdateTreeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTreeResponse(request.CorrelationId());

            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingItem is null) return NotFound();

            existingItem.UpdateDetails(request.Name);

            await _itemRepository.UpdateAsync(existingItem, cancellationToken);

            var dto = new TreeDto
            {
                Id = existingItem.Id,
                Name = existingItem.Name
            };
            response.Tree = dto;
            return response;
        }
    }
}