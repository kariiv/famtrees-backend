using System.Threading.Tasks;

namespace FamTrees.Core.Interfaces
{
    public interface IFamilyService
    {
        Task NumerateChildrenInFamily(int treeId, int personId);
        Task GetYoungestPibling(int treeId, int personId);
    }
}
