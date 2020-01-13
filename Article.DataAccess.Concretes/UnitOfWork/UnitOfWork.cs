using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

#region Custom Usings
using Article.Common.Helpers;
using Article.Common.Constants;
using Article.DataAccess.Abstracts.UnitOfWork;
using Article.Models.EntitiesOfProjects.DBContexts;
using Article.DataAccess.Abstracts.RepositoryOfEntities;
#endregion
namespace Article.DataAccess.Concretes.UnitOfWork
{
    #region Internal Usings
    using RepositoryOfEntities;
    #endregion

    public class UnitOfWork : IUnitOfWork
    {
        #region Global Properties

        private bool disposedValue;

        private readonly object lockObjectForRepositoryOfUser;
        private readonly object lockObjectForRepositoryOfPost;
        private readonly object lockObjectForRepositoryOfCategory;

        private readonly DbContext DbContext;
        private IDbContextTransaction DbContextTransaction;

        private IRepositoryOfUser repositoryOfUser;
        private IRepositoryOfPost repositoryOfPost;
        private IRepositoryOfCategory repositoryOfCategory;

        #endregion Global Properties

        #region Constructor(s)

        public UnitOfWork(DbContext dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForDbContext,
                                                                          innerException: null);

            //Eger DbContext bos degilse geri kalan islemler yapilmaya baslansin

            this.disposedValue = default(bool);

            this.lockObjectForRepositoryOfUser = new object();
            this.lockObjectForRepositoryOfPost = new object();
            this.lockObjectForRepositoryOfCategory = new object();
        }

        #endregion Constructor(s)

        #region Property of Repositories

        IRepositoryOfUser IUnitOfWork.RepositoryOfUser
        {
            get
            {
                if (this.repositoryOfUser == null)
                {
                    lock (this.lockObjectForRepositoryOfUser)
                    {
                        if (this.repositoryOfUser == null)
                        {
                            if (this.CheckInitializeDbContextWithDbContextsRepositories(typeOfDbContext: typeof(ArticleContext)))
                            {
                                this.repositoryOfUser = new RepositoryOfUser(dbContext: this.DbContext);
                            }
                            else
                            {
                                throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForArticleContext,
                                                                innerException: null);
                            }
                        }
                    }
                }
                return this.repositoryOfUser;
            }
        }

        IRepositoryOfPost IUnitOfWork.RepositoryOfPost
        {
            get
            {
                if (this.repositoryOfPost == null)
                {
                    lock (this.lockObjectForRepositoryOfPost)
                    {
                        if (this.repositoryOfPost == null)
                        {
                            if (this.CheckInitializeDbContextWithDbContextsRepositories(typeOfDbContext: typeof(ArticleContext)))
                            {
                                this.repositoryOfPost = new RepositoryOfPost(dbContext: this.DbContext);
                            }
                            else
                            {
                                throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForArticleContext,
                                                                innerException: null);
                            }
                        }
                    }
                }
                return this.repositoryOfPost;
            }
        }

        IRepositoryOfCategory IUnitOfWork.RepositoryOfCategory
        {
            get
            {
                if (this.repositoryOfCategory == null)
                {
                    lock (this.lockObjectForRepositoryOfCategory)
                    {
                        if (this.repositoryOfCategory == null)
                        {
                            if (this.CheckInitializeDbContextWithDbContextsRepositories(typeOfDbContext: typeof(ArticleContext)))
                            {
                                this.repositoryOfCategory = new RepositoryOfCategory(dbContext: this.DbContext);
                            }
                            else
                            {
                                throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForArticleContext,
                                                                innerException: null);
                            }
                        }
                    }
                }
                return this.repositoryOfCategory;
            }
        }

        #endregion Property of Repositories


        #region Transaction Functions

        void IUnitOfWork.BeginTransaction()
        {
            Tools.TryCatch(action: () =>
            {
                this.DbContextTransaction = this.DbContext.Database.BeginTransaction(isolationLevel: System.Data.IsolationLevel.ReadUncommitted);
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            });
        }

        void IUnitOfWork.CommitTransaction()
        {
            if (this.DbContextTransaction != null)
            {
                Tools.TryCatch(action: () =>
                {
                    this.DbContextTransaction.Commit();
                },
                catchAndDo: (Exception exception) =>
                {
                    this.DbContextTransaction.Rollback();
                    throw exception;
                },
                finallyAndDo: () =>
                {
                    this.DbContextTransaction.Dispose();
                });
            }
            else
            {
                throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForDbContextTransaction,
                                                innerException: null);
            }
        }

        void IUnitOfWork.RollbackTransaction()
        {
            if (this.DbContextTransaction != null)
            {
                Tools.TryCatch(action: () =>
                {
                    this.DbContextTransaction.Rollback();
                },
                catchAndDo: (Exception exception) =>
                {
                    this.DbContextTransaction.Rollback();
                    throw exception;
                },
                finallyAndDo: () =>
                {
                    this.DbContextTransaction.Dispose();
                });
            }
            else
            {
                throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForDbContextTransaction,
                                               innerException: null);
            }
        }

        #endregion Transaction Functions

        #region SaveChanges Function(s)

        int IUnitOfWork.SaveChanges()
        {
            return Tools.TryCatch<int>(function: () =>
            {
                return this.DbContext
                           .SaveChanges();
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            });
        }

        #endregion SaveChanges Function(s)

        #region Private Function(s)

        /// <summary>
        /// UnitOfWork'un initialize DbContext nesnesi ile UnitOfWork'de olan Repository propertylerine ait 
        /// tablolarin icinde oldugu DbContext nesnesi ayni mi diye kontrol eden fonksiyon
        /// </summary>
        /// <param name="typeOfDbContext">UnitOfWork initialize DbContex'i ile karsilastirilmak istenilen DbContext</param>
        /// <returns></returns>
        private bool CheckInitializeDbContextWithDbContextsRepositories(Type typeOfDbContext)
        {
            bool result = default(bool);

            if (typeOfDbContext != null)
            {
                result = typeOfDbContext == this.DbContext.GetType();
            }
            else
            {
                throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForDbContext,
                                                innerException: null);
            }

            return result;
        }

        #endregion Private Function(s)

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.DbContextTransaction != null)
                    {
                        this.DbContextTransaction.Dispose();
                    }
                    this.DbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}
