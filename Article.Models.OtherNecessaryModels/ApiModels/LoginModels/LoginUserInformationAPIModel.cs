using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.LoginModels
{
    public class LoginUserInformationAPIModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public DateTime UserCreationDate { get; set; }
    }
}
