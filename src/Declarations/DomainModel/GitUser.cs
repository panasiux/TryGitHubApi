using System.Collections.Generic;
using Declarations.Interfaces.DomainEntities;

namespace Declarations.DomainModel
{
    public class GitUser : IDomainEntity, IGitUser
    {
        public string Name { set; get; }
        public string Login { set; get; }
        public string Location { set; get; }
        public List<GitUser> Followers { set; get; } = new List<GitUser>();
    }
}
