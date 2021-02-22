using System.Threading.Tasks;

namespace FamTrees.Core.Interfaces
{
    public interface IFamilyTreeService
    {
        public Task AddParentForPerson(int personId, int parentId);
        public Task GetPersonWithMostPredecessors(int treeId);
    }
}
