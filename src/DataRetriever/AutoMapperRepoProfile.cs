using AutoMapper;
using Declarations.DomainModel;
using GitHubGrapthQlDataRetriever.Docs;

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
