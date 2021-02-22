using FamTrees.Core.Interfaces;
using System.Threading.Tasks;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Core.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IAppLogger<FamilyService> _logger;

        public FamilyService(IAsyncRepository<Person> personRepository, IAppLogger<FamilyService> logger)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        Task IFamilyService.GetYoungestPibling(int treeId, int personId)
        {
            throw new System.NotImplementedException();
        }

        Task IFamilyService.NumerateChildrenInFamily(int treeId, int personId)
        {
            throw new System.NotImplementedException();
        }
    }
}
