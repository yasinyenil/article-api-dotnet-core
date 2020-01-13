using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Article.Common.Helpers;
using Article.Models.EntitiesOfProjects.Entities;
using Article.Models.OtherNecessaryModels.ApiModels.UserModels;
#endregion

namespace Article.Managers.Concretes
{
    #region Internal Usings
    using Base;
    using Abstracts;
    #endregion

    public class ManagerUser : BaseManager, IManagerUser
    {
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
    }
}
