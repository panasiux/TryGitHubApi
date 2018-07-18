namespace Declarations.Interfaces.DomainEntities
{
    public interface IGitUser
    {
        string Name { set; get; }
        string Login { set; get; }
        string Location { set; get; }
    }
}