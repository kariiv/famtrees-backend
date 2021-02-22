using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using FamTrees.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class List : BaseAsyncEndpoint<ListRequest, ListResponse>
    {
        private readonly IAsyncRepository<PersonParent> _repository;
        private readonly IMapper _mapper;

        public List(IAsyncRepository<PersonParent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/tree-parents/{TreeId}")]
        [SwaggerOperation(
            Summary = "List Tree Parents",
            Description = "List Tree Parents",
            OperationId = "tree-parent.ListParents",
            Tags = new[] { "PersonParentEndpoints" })
        ]
        public override async Task<ActionResult<ListResponse>> HandleAsync([FromRoute] ListRequest request, CancellationToken cancellationToken)
        {
            var response = new ListResponse(request.CorrelationId());
            var spec = new PersonParentByTreeSpecification(request.TreeId);
            var items = await _repository.ListAsync(spec, cancellationToken);
            response.PersonParents.AddRange(items.Select(_mapper.Map<PersonParentDto>));
            return Ok(response);
        }
    }
}
