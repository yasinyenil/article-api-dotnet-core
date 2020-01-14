using System;
using System.Collections.Generic;
using System.Text;
using Article.Models.EntitiesOfProjects.Entities;

#region Global Usings
using Article.Models.OtherNecessaryModels.ApiModels.UserModels;
#endregion

namespace Article.Managers.Abstracts
{
    public interface IManagerUser : IDisposable
    {
        bool CreateNewUser(NewUserAPIModel newUserInformation);

        List<User> ListUser();

        User GetUser(int id);

        bool UpdateUser(User user);

        bool DeleteUser(int id);
    }
}
