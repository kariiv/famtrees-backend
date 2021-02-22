using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class GetById : BaseAsyncEndpoint<GetByIdTreeRequest, GetByIdTreeResponse>
    {
    private readonly IAsyncRepository<Tree> _itemRepository;

    public GetById(IAsyncRepository<Tree> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpGet("api/tree/{TreeId}")]
    [SwaggerOperation(
        Summary = "Get a Tree by Id",
        Description = "Get a Tree by Id",
        OperationId = "trees.get-by-id",
        Tags = new[] { "TreeEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdTreeResponse>> HandleAsync([FromRoute] GetByIdTreeRequest request, CancellationToken cancellationToken)
    {
        var response = new GetByIdTreeResponse(request.CorrelationId());

        var getById = await _itemRepository.GetByIdAsync(request.TreeId, cancellationToken);
        if (getById is null) return NotFound();

        var dto = new TreeDto
        {
            Id = getById.Id,
            Name = getById.Name
        };
        response.Tree = dto;
        return response;
    }
}
}