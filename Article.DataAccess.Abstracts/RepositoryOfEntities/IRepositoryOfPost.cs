#region Custom Usings
using Article.Models.EntitiesOfProjects.Entities;
#endregion Custom Usings

namespace Article.DataAccess.Abstracts.RepositoryOfEntities
{
    #region Internal Usings
    using RepositoryBase;
    #endregion Internal Usings

    public interface IRepositoryOfPost : IRepositorySelectable<Post>, IRepositoryUpdatable<Post>, IRepositoryInsertable<Post>
    {
    }
}
