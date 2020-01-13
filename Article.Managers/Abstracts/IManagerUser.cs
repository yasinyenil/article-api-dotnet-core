using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Article.Models.OtherNecessaryModels.ApiModels.UserModels;
#endregion

namespace Article.Managers.Abstracts
{
    public interface IManagerUser
    {
        bool CreateNewUser(NewUserAPIModel newUserInformation);
    }
}
