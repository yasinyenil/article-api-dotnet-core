using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.LoginModels
{
    using ResultModels;

    public class LoginInformationAPIModel
    {
        public ResultModel ResultInformation { get; set; }
        public LoginUserInformationAPIModel UserInformation { get; set; }
    }
}
