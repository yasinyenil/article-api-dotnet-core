using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.UserModels
{
    using ResultModels;

    public sealed class ResultListUserAPIModel
    {
        public ResultModel ResultInformation { get; set; }
        public ListUserAPIModel UserInformation { get; set; }
    }
}
