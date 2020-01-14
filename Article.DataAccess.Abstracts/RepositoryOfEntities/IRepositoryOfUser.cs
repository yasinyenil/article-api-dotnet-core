#region Custom Usings
using Article.Models.EntitiesOfProjects.Entities;
#endregion Custom Usings

namespace Article.DataAccess.Abstracts.RepositoryOfEntities
{
    #region Internal Usings
    using RepositoryBase;
    #endregion Internal Usings

    public interface IRepositoryOfUser : IRepositorySelectable<User>, IRepositoryUpdatable<User>, IRepositoryInsertable<User>, IRepositoryDeletable<User>
    {
    }
}
