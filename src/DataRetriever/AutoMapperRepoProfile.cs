using AutoMapper;
using Declarations.DomainModel;
using GiHubGrapthQlDataRetriever.Docs;

namespace GitHubGrapthQlDataRetriever
{
    public class AutoMapperRepoProfile : Profile
    {
        public AutoMapperRepoProfile()
        {
            CreateMap<UserDoc, GitUser>(); 
        }
    }

}
