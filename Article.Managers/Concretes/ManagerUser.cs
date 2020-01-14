using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#region Global Usings
using Article.Common.Helpers;
using Article.Models.EntitiesOfProjects.Entities;
using Article.Models.OtherNecessaryModels.ApiModels.UserModels;
#endregion

namespace Article.Managers.Concretes
{
    #region Internal Usings
    using Abstracts;
    using Base;
    #endregion

    public class ManagerUser : BaseManager, IManagerUser
    {
        public bool DeleteUser(int id)
        {

            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var user = this.UnitOfWork.RepositoryOfUser.GetItem(id);
                this.UnitOfWork.RepositoryOfUser.DeleteItem(user);

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

        public User GetUser(int id)
        {
            return this.UnitOfWork.RepositoryOfUser.GetItem(id);
        }

        public List<User> ListUser()
        {
            return this.UnitOfWork.RepositoryOfUser.GetAllItems();
        }

        public bool UpdateUser(User user)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var updatedUser = this.UnitOfWork.RepositoryOfUser.GetItem(user.Id);
                updatedUser.FirstName = user.FirstName == null ? updatedUser.FirstName : user.FirstName; ;
                updatedUser.LastName = user.LastName == null ? updatedUser.LastName : user.LastName; ;
                updatedUser.ModifiedDate = DateTime.Now;
                updatedUser.Password = user.Password == null ? updatedUser.Password : user.Password;
                updatedUser.UserName = user.UserName == null ? updatedUser.UserName : user.UserName;


                this.UnitOfWork.RepositoryOfUser.UpdateItem(updatedUser);

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

        bool IManagerUser.CreateNewUser(NewUserAPIModel newUserInformation)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var addedItem = this.UnitOfWork.RepositoryOfUser.InsertItem(insertItem: new User
                {
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    LastName = newUserInformation.LastName,
                    UserName = newUserInformation.UserName,
                    FirstName = newUserInformation.FirstName,
                    Password = newUserInformation.UserPassword
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
        // ~ManagerUser() {
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
