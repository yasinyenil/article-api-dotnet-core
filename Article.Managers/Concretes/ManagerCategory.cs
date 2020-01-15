namespace Article.Managers.Concretes
{
    #region Internal Usings
    using Base;
    using Abstracts;
    using Article.Models.OtherNecessaryModels.ApiModels.CategoryModels;
    using System.Collections.Generic;
    using Article.Models.EntitiesOfProjects.Entities;
    using Article.Common.Helpers;
    using System;
    #endregion Internal Usings

    public class ManagerCategory : BaseManager, IManagerCategory
    {
        public bool CreateNewCategory(NewCategoryAPIModel newCategoryAPIModel)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var addedItem = this.UnitOfWork.RepositoryOfCategory.InsertItem(insertItem: new Category
                {
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                });

                numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                if (numberOfRowsAffected > 0)
                {
                    this.UnitOfWork.CommitTransaction();
                    return true;
                }
                else
                {
                    this.UnitOfWork.RollbackTransaction();
                    return false;
                }
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            },
            finallyAndDo: () =>
            {
                this.UnitOfWork.Dispose();
            });
        }

        public bool DeleteCategory(int id)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var category = this.UnitOfWork.RepositoryOfCategory.GetItem(id);
                this.UnitOfWork.RepositoryOfCategory.DeleteItem(category);

                numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                if (numberOfRowsAffected > 0)
                {
                    this.UnitOfWork.CommitTransaction();
                    return true;
                }
                else
                {
                    this.UnitOfWork.RollbackTransaction();
                    return false;
                }
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            },
            finallyAndDo: () =>
            {
                this.UnitOfWork.Dispose();
            });
        }

        public Category GetCategory(int id)
        {
            return this.UnitOfWork.RepositoryOfCategory.GetItem(id);
        }

        public List<Category> ListCategory()
        {
            return this.UnitOfWork.RepositoryOfCategory.GetAllItems();
        }
        
        public bool UpdateCategory(Category category)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var updatedCategory = this.UnitOfWork.RepositoryOfCategory.GetItem(category.Id);

                updatedCategory.ModifiedDate = DateTime.Now;
                updatedCategory.Name = category.Name == null ? updatedCategory.Name : category.Name;

                this.UnitOfWork.RepositoryOfCategory.UpdateItem(category);

                numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                if (numberOfRowsAffected > 0)
                {
                    this.UnitOfWork.CommitTransaction();
                    return true;
                }
                else
                {
                    this.UnitOfWork.RollbackTransaction();
                    return false;
                }
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            },
            finallyAndDo: () =>
            {
                this.UnitOfWork.Dispose();
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ManagerCategory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    
}
