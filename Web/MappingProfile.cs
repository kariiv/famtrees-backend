using AutoMapper;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Web.Endpoints.PersonEndpoints;
using FamTrees.Web.Endpoints.PersonParentEndpoints;
using FamTrees.Web.Endpoints.TreeEndpoints;

namespace FamTrees.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Tree, TreeDto>();
            CreateMap<PersonParent, PersonParentDto>();
        }
    }
}
