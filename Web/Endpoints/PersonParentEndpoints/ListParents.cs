using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using FamTrees.Core.Specifications;
using FamTrees.Web.Endpoints.PersonEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonParentEndpoints
{
    public class ListFromTree : BaseAsyncEndpoint<ListParentsRequest, ListParentsResponse>
    {
        private readonly IAsyncRepository<PersonParent> _repository;
        private readonly IMapper _mapper;

        public ListFromTree(IAsyncRepository<PersonParent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/person-parents/{PersonId}")]
        [SwaggerOperation(
            Summary = "List Person Parents",
            Description = "List Person Parents",
            OperationId = "person-parent.ListParents",
            Tags = new[] { "PersonParentEndpoints" })
        ]
        public override async Task<ActionResult<ListParentsResponse>> HandleAsync([FromRoute] ListParentsRequest request, CancellationToken cancellationToken)
        {
            var response = new ListParentsResponse(request.CorrelationId());
            var specification = new PersonParentSpecification(request.PersonId);

            var items = await _repository.ListAsync(specification, cancellationToken);

            response.Parents.AddRange(items.Select(x => x.Parent.Id));
            return Ok(response);
        }
    }
}
