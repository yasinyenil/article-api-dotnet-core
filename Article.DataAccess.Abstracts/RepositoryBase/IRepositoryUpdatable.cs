#region Custom Usings
using Article.Models.EntitiesOfProjects.BaseEntity;
#endregion Custom Usings

namespace Article.DataAccess.Abstracts.RepositoryBase
{
    public interface IRepositoryUpdatable<T> where T : class, IBaseEntity
    {
        /// <summary>
        /// Herhangi bir tablodaki kayiti guncelleyen fonksiyon
        /// </summary>
        /// <param name="updateItem">Guncellenecek olan kayita ait "YENI" bilgiler</param>
        /// <returns></returns>
        T UpdateItem(T updateItem);
    }
}
