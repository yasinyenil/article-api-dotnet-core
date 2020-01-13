using Article.DataAccess.Abstracts.UnitOfWork;
using Article.DataAccess.Concretes.UnitOfWork;
using Article.Models.EntitiesOfProjects.DBContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Managers.Base
{
    public abstract class BaseManager
    {
        #region Global Properties
        private IUnitOfWork unitOfWork;
        private readonly object lockObjectForUnitOfWork;
        #endregion Global Properties

        #region Constructor(s)

        protected BaseManager()
        {
            this.lockObjectForUnitOfWork = new object();
        }

        #endregion Constructor(s)

        /// <summary>
        /// ToDoList DBContext'ine ait tablolarin, Database uzerinde islem yapmak icin Entity'ler icin Singleton olarak olusturulan Repository'lere ulasmayi saglayan property.
        /// <para>NOT : Baska bir DBContext'e ulasilmak isteniliyorsa 1-> Models projesinde DbContext 2-> DataAccess'de Entityler icin
        /// ITableNameOfRepository ve TableNameOfRepository classlari 3-> IUnitOfWork ve UnitOfWork classlari icinde Singleton Property leri 
        /// olusturmalisiniz. Sonrasinda bu property'i istenilen Manager class'i icerisinde override ederek yeni olusturulan DbContext nesnesini 
        /// kullanabilirsiniz</para>
        /// </summary>
        protected virtual IUnitOfWork UnitOfWork
        {
            get
            {
                if (this.unitOfWork == null)
                {
                    lock (this.lockObjectForUnitOfWork)
                    {
                        if (this.unitOfWork == null)
                        {
                            this.unitOfWork = new UnitOfWork(new ArticleContext());
                        }
                    }
                }
                return this.unitOfWork;
            }
        }

    }
}
