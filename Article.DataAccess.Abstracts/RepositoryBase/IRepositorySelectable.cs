using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#region Custom Usings
using Article.Models.EntitiesOfProjects.BaseEntity;
#endregion Custom Usings

namespace Article.DataAccess.Abstracts.RepositoryBase
{
    public interface IRepositorySelectable<T> where T : class, IBaseEntity
    {
        /// <summary>
        /// Herhangi bir sart olmadan tum kayitlari listeler.
        /// </summary>
        /// <returns></returns>
        List<T> GetAllItems();

        /// <summary>
        /// Verilen Where Case degeri / degerlerine gore tum kayitlari listeler.
        /// </summary>
        /// <param name="predicate">Filtrele yapmak icin gerekli deger / degerler</param>
        /// <returns></returns>
        IQueryable<T> GetAllItems(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Verilen Id degerine gore tek bir kayidi listeler
        /// </summary>
        /// <param name="id">Listelenmek istenilen kayita ait Id bilgisi</param>
        /// <returns>Id sonucunda deger var ise T tipinde entity, deger yok ise Null deger donecektir</returns>
        T GetItem(object id);

        /// <summary>
        /// Verilen Where Case degeri / degerlerine gore tek bir kayidi listeler
        /// </summary>
        /// <param name="predicate">Filtrele yapmak icin gerekli deger / degerler</param>
        /// <returns></returns>
        T GetItem(Expression<Func<T, bool>> predicate);
    }
}
