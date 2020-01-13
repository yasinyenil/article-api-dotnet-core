using Microsoft.EntityFrameworkCore;

#region Custom Usings
using Article.DataAccess.Abstracts.RepositoryOfEntities;
using Article.Models.EntitiesOfProjects.Entities;
#endregion Custom Usings

namespace Article.DataAccess.Concretes.RepositoryOfEntities
{
    #region Internal Usings
    using RepositoryBase;
    #endregion Internal Usings

    public class RepositoryOfCategory : RepositoryOfBase<Category>, IRepositoryOfCategory
    {
        public RepositoryOfCategory(DbContext dbContext) : base(dbContext)
        {
        }
    }

}
