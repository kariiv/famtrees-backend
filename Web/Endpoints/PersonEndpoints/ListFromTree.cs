using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using FamTrees.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class ListFromTree : BaseAsyncEndpoint<ListFromTreeRequest, ListFromTreeResponse>
    {
        private readonly IAsyncRepository<Tree> _repository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ListFromTree> _logger;

        public ListFromTree(IAsyncRepository<Tree> repository, IMapper mapper, IAppLogger<ListFromTree> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("api/tree-people/{TreeId}")]
        [SwaggerOperation(
            Summary = "List People from Tree",
            Description = "List People from Tree",
            OperationId = "tree-people.ListPeople",
            Tags = new[] { "PersonEndpoints" })
        ]
        public override async Task<ActionResult<ListFromTreeResponse>> HandleAsync([FromRoute] ListFromTreeRequest request, CancellationToken cancellationToken)
        {
            var response = new ListFromTreeResponse(request.CorrelationId());

            var spec = new TreeWithPeopleSpecification(request.TreeId);

            var tree = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
            if (tree == null) return NotFound();

            if (tree.People.Count == 0) return Ok(response);
            
            response.People.AddRange(tree.People.Select(_mapper.Map<PersonDto>));
            return Ok(response);
        }
    }
}
