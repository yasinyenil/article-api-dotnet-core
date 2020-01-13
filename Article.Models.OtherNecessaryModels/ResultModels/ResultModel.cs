using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ResultModels
{
    public class ResultModel
    {
        ResultModel()
        {
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; } = string.Empty;

        static ResultModel CreateResult(bool isSuccess, string message = "") => new ResultModel
        {
            IsSuccess = isSuccess,
            Message = message
        };

        public static ResultModel SuccessResult(string message = "") => CreateResult(isSuccess: true, message: message);

        public static ResultModel UnSuccessResult(string message = "") => CreateResult(isSuccess: false, message: message);

    }
}
