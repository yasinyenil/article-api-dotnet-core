using Article.Models.EntitiesOfProjects.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.DataAccess.Abstracts.RepositoryBase
{
    public interface IRepositoryDeletable<T> where T : class, IBaseEntity
    {
        T DeleteItem(T deletedItem);
    }
}
