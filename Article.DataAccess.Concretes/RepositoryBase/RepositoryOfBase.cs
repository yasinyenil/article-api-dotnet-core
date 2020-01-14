using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#region Custom Usings
using Article.Common.Helpers;
using Article.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Article.DataAccess.Abstracts.RepositoryBase;
using Article.Models.EntitiesOfProjects.BaseEntity;
#endregion Custom Usings

namespace Article.DataAccess.Concretes.RepositoryBase
{
    public abstract class RepositoryOfBase<T> : IRepositoryInsertable<T>, IRepositorySelectable<T>, IRepositoryUpdatable<T>, IRepositoryDeletable<T>
        where T : class, IBaseEntity
    {

        #region Global Properties
        protected DbContext DbContext { get; private set; }
        protected DbSet<T> DbSet { get; private set; }
        #endregion Global Properties

        #region Constructor(s)
        protected RepositoryOfBase(DbContext dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(message: ErrorConstants.ArgumentNullExceptionMessageForDbContext,
                                                                          innerException: null);
            this.DbSet = this.DbContext.Set<T>();
        }
        #endregion Constructor(s)

        #region Select Functions

        List<T> IRepositorySelectable<T>.GetAllItems()
        {
            return Tools.TryCatch<List<T>>(function: () =>
            {
                return this.DbSet.ToList();
            },
            catchAndDo: (Exception ex) =>
            {
                throw ex;
            });
        }


        IQueryable<T> IRepositorySelectable<T>.GetAllItems(Expression<Func<T, bool>> predicate)
        {
            return this.DbSet.Where(predicate: predicate)
                             .AsQueryable();
        }


        T IRepositorySelectable<T>.GetItem(object id)
        {
            return Tools.TryCatch<T>(function: () =>
            {
                return this.DbSet.Find(keyValues: id);
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            });
        }


        T IRepositorySelectable<T>.GetItem(Expression<Func<T, bool>> predicate)
        {
            return Tools.TryCatch<T>(function: () =>
            {
                return this.DbSet.SingleOrDefault(predicate: predicate);
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            });
        }

        #endregion Select Functions 

        #region Insert Function(s)

        T IRepositoryInsertable<T>.InsertItem(T insertItem)
        {
            return this.AttachItemToDbSet(itemToAdd: insertItem, itemTransactionState: EntityState.Added);
        }

        #endregion Insert Function(s) 


        #region Update Function(s)

        T IRepositoryUpdatable<T>.UpdateItem(T updateItem)
        {
            return this.AttachItemToDbSet(itemToAdd: updateItem, itemTransactionState: EntityState.Modified);
        }

        #endregion Update Function(s) 

        #region Delete Function(s)

        T IRepositoryDeletable<T>.DeleteItem(T deletedItem)
        {
            return this.AttachItemToDbSet(itemToAdd: deletedItem, itemTransactionState: EntityState.Modified);
        }

        #endregion Delete Function(s)


        #region Private Function(s)

        T AttachItemToDbSet(T itemToAdd, EntityState itemTransactionState)
        {
            var itemToAttach = this.DbSet.Attach(entity: itemToAdd);
            itemToAttach.State = itemTransactionState;
            return itemToAttach.Entity;
        }

        #endregion Private Function(s)

    }
}
