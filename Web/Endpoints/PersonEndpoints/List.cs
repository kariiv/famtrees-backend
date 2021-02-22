using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class List : BaseAsyncEndpoint<ListPersonResponse>
    {
        private readonly IAsyncRepository<Person> _repository;
        private readonly IMapper _mapper;
    
        public List(IAsyncRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    
        [HttpGet("api/people")]
        [SwaggerOperation(
            Summary = "List People",
            Description = "List People",
            OperationId = "people.List",
            Tags = new[] { "PersonEndpoints" })
        ]
        public override async Task<ActionResult<ListPersonResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListPersonResponse();
            var items = await _repository.ListAllAsync(cancellationToken);
    
            response.People.AddRange(items.Select(_mapper.Map<PersonDto>));
            return Ok(response);
        }
    }
}