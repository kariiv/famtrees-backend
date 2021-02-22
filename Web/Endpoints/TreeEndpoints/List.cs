using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.TreeEndpoints
{
    public class List : BaseAsyncEndpoint<ListTreeResponse>
    {
        private readonly IAsyncRepository<Tree> _repository;
        private readonly IMapper _mapper;

        public List(IAsyncRepository<Tree> catalogTypeRepository,
            IMapper mapper)
        {
            _repository = catalogTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("api/trees")]
        [SwaggerOperation(
            Summary = "List Family Trees",
            Description = "List Family Trees",
            OperationId = "trees.List",
            Tags = new[] { "TreeEndpoints" })
        ]
        public override async Task<ActionResult<ListTreeResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListTreeResponse();
            var items = await _repository.ListAllAsync(cancellationToken);
            response.Trees.AddRange(items.Select(_mapper.Map<TreeDto>));
            return Ok(response);
        }
    }
}