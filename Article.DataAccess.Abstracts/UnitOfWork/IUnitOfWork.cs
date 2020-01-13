using System;
using System.Collections.Generic;
using System.Text;

#region Custom Usings

using Article.DataAccess.Abstracts.RepositoryOfEntities;

#endregion

namespace Article.DataAccess.Abstracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region Save Changes Function
        int SaveChanges();
        #endregion


        #region Database Transaction Functions

        /// <summary>
        /// Database uzerinde Insert, Update ve Delete islemleri yapilirken olusabilecek herhangi bir hata durumunda RollBack yonetimini yapabilmek
        /// icin Database'e ulasilma aninda direkt olarak Begin Transaction baslatan fonksiyon
        /// </summary>
        /// <returns></returns>
        void BeginTransaction();

        /// <summary>
        /// Database uzerinde yapilan Insert - Update ve Delete islemleri icin herhangi bir hata durumu yoksa yapilan degisiklikleri veritabanina 
        /// kayit edilmesini saglayan fonksiyon
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Database uzerinde yapilan Insert - Update ve Delete islemleri icin yapilan islemlerde herhangi bir hata oldugunda tum degisiklikleri geri
        /// almaya yarayan fonksiyon
        /// </summary>
        void RollbackTransaction();

        #endregion Database Transaction Functions

        #region Repository Properties

        /// <summary>
        /// User tablosuna ait Base ve Custom fonksiyonlarin yazilmis oldugu class'a Singleton ulasmayi saglayan property
        /// </summary>
        IRepositoryOfUser RepositoryOfUser { get; }

        /// <summary>
        /// Category tablosuna ait Base ve Custom fonksiyonlarin yazilmis oldugu class'a Singleton ulasmayi saglayan property
        /// </summary>
        IRepositoryOfCategory RepositoryOfCategory { get; }

        /// <summary>
        /// Post tablosuna ait Base ve Custom fonksiyonlarin yazilmis oldugu class'a Singleton ulasmayi saglayan property
        /// </summary>
        IRepositoryOfPost RepositoryOfPost { get; }

        #endregion Repository Properties
    }
}
