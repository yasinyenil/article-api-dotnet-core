using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.UserModels
{
    using ResultModels;

    public sealed class ResultUpdateUserAPIModel
    {
        public ResultModel ResultInformation { get; set; }
        public UpdateUserAPIModel UserInformation { get; set; }
    }
}
