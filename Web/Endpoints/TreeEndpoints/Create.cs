using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class Create : BaseAsyncEndpoint<NewTreeRequest, NewTreeResponse>
    {
        private readonly IAsyncRepository<Tree> _itemRepository;

        public Create(IAsyncRepository<Tree> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost("api/trees")]
        [SwaggerOperation(
            Summary = "Create a Family Tree",
            Description = "Create a Family Tree",
            OperationId = "trees.create",
            Tags = new[] { "TreeEndpoints" })
        ]
        public override async Task<ActionResult<NewTreeResponse>> HandleAsync(NewTreeRequest request, CancellationToken cancellationToken)
        {
            var response = new NewTreeResponse(request.CorrelationId());

            var newItem = new Tree(request.Name);

            newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

            var dto = new TreeDto
            {
                Id = newItem.Id,
                Name = newItem.Name
            };
            response.Tree = dto;
            return response;
        }
    }
}