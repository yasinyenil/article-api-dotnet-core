using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.UserModels
{
    /// <summary>
    /// User tablosuna API uzerinden yapilacak olan tum Create islemleri icin kullanilacak olan class
    /// </summary>
    public sealed class NewUserAPIModel : BaseAPIModelForUser
    {
        public string UserPassword { get; set; }
    }
}
