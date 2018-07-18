using Declarations.Interfaces.DomainEntities;

namespace GiHubGrapthQlDataRetriever.Docs
{
    public class UserDoc : IGitUser
    {
        public string Name { set; get; }
        public string Login { get; set; }
        public string Location { set; get; }
    }
}
