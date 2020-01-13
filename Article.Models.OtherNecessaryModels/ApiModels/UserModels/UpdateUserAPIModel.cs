using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.UserModels
{
    /// <summary>
    /// User tablosuna API uzerinden yapilacak olan tum Update islemleri icin kullanilacak olan class
    /// </summary>
    public sealed class UpdateUserAPIModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
