using System;
using System.Collections.Generic;
using System.Text;

#region Custom Usings
using Article.Models.EntitiesOfProjects.Entities;
#endregion Custom Usings

namespace Article.DataAccess.Abstracts.RepositoryOfEntities
{
    #region Internal Usings
    using RepositoryBase;
    #endregion Internal Usings

    public interface IRepositoryOfCategory : IRepositorySelectable<Category>, IRepositoryUpdatable<Category>, IRepositoryInsertable<Category>
    {
    }
}
