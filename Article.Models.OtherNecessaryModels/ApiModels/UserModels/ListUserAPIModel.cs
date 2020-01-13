using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.UserModels
{
    /// <summary>
    /// User tablosuna API uzerinden yapilacak olan tum Read (Select) islemleri icin kullanilacak olan class
    /// </summary>
    public sealed class ListUserAPIModel : BaseAPIModelForUser
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
