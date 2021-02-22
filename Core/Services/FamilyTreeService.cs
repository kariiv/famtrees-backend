using System;
using System.Threading.Tasks;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Exceptions;
using FamTrees.Core.Interfaces;
using FamTrees.Core.Specifications;

namespace FamTrees.Core.Services
{
    public class FamilyTreeService : IFamilyTreeService
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IAsyncRepository<PersonParent> _parentRepository;
        private readonly IAppLogger<FamilyTreeService> _logger;

        public FamilyTreeService(IAppLogger<FamilyTreeService> logger, 
            IAsyncRepository<Person> personRepository, 
            IAsyncRepository<PersonParent> parentRepository)
        {
            _logger = logger;
            _parentRepository = parentRepository;
            _personRepository = personRepository;
        }


        public async Task AddParentForPerson(int personId, int parentId)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            var parent = await _personRepository.GetByIdAsync(parentId);

            if (person == null || parent == null) 
                throw new ("People not found");

            var spec = new PersonParentSpecification(personId);
            var items = await _parentRepository.ListAsync(spec);

            if (items.Count > 1)
            {
                throw new PersonHasParentsException("Person can have only one Mother and Father");
            }

            if (items.Count == 1 && items[0].Parent.Sex == parent.Sex)
            {
                if (parent.Sex == Sex.Male)
                {
                    throw new PersonHasParentsException("Person already have a Father");
                }
                throw new PersonHasParentsException("Person already have a Mother");
            }
            _logger.LogInformation(person.ToString());
            _logger.LogInformation(parent.ToString());
            await _parentRepository.AddAsync(new PersonParent(person, parent));
        }

        public Task GetPersonWithMostPredecessors(int treeId)
        {
            throw new NotImplementedException();
        }
    }
}
