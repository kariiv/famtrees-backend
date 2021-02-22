using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FamTrees.Web.Endpoints.PersonEndpoints
{
    public class Create : BaseAsyncEndpoint<CreatePersonRequest, CreatePersonResponse>
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IAsyncRepository<Tree> _treeRepository;
        private readonly IAppLogger<Create> _logger;

        public Create(IAsyncRepository<Person> personRepository, IAsyncRepository<Tree> treeRepository, IAppLogger<Create> logger)
        {
            _personRepository = personRepository;
            _treeRepository = treeRepository;
            _logger = logger;
        }

        [HttpPost("api/people")]
        [SwaggerOperation(
            Summary = "Create a Person",
            Description = "Create a Person",
            OperationId = "people.create",
            Tags = new[] { "PersonEndpoints" })
        ]
        public override async Task<ActionResult<CreatePersonResponse>> HandleAsync(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePersonResponse(request.CorrelationId());

            var tree = await _treeRepository.GetByIdAsync(request.TreeId, cancellationToken);
            if (tree == null) return NotFound("No tree found with given id");

            _logger.LogInformation(request.DeathDate.ToString());

            var newItem = new Person(tree.Id, request.FirstName, request.LastName, request.Sex, request.Birthday, request.DeathDate);
            
            newItem = await _personRepository.AddAsync(newItem, cancellationToken);

            var dto = new PersonDto
            {
                Id = newItem.Id,
                FirstName = newItem.FirstName,
                LastName = newItem.LastName,
                Birthday = newItem.Birthday,
                DeathDate = newItem.DeathDate,
                Sex = newItem.Sex,
                TreeId = newItem.TreeId
            };
            response.Person = dto;
            return response;
        }
    }
}