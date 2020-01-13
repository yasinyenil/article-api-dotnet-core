using Microsoft.EntityFrameworkCore;

#region Custom Usings
using Article.DataAccess.Abstracts.RepositoryOfEntities;
using Article.Models.EntitiesOfProjects.Entities;
#endregion Custom Usings

namespace Article.DataAccess.Concretes.RepositoryOfEntities
{
    #region Internal Usings
    using Article.DataAccess.Concretes.RepositoryBase;
    #endregion Internal Usings

    public class RepositoryOfUser : RepositoryOfBase<User>, IRepositoryOfUser
    {
        public RepositoryOfUser(DbContext dbContext) : base(dbContext)
        {
        }
    }

}
