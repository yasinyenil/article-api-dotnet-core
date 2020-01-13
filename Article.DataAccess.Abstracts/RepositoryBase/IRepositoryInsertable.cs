
#region Custom Usings
using Article.Models.EntitiesOfProjects.BaseEntity;
#endregion Custom Usings

namespace Article.DataAccess.Abstracts.RepositoryBase
{
    public interface IRepositoryInsertable<T> where T : class, IBaseEntity
    {
        /// <summary>
        /// Herhangi bir tabloya kayit eklemek icin kullanilan fonksiyon
        /// </summary>
        /// <param name="insertItem">Eklenmek istenilen kayita ait bilgiler</param>
        /// <returns></returns>
        T InsertItem(T insertItem);

    }
}
