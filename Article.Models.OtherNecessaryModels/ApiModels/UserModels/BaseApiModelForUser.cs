using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.UserModels
{
   
        /// <summary>
        /// User tablosuna API uzerinden yapilacak olan tum CRU (Create - Read (Select) - Update) islemleri icin kullanilan ortak ozellikleri iceren class
        /// </summary>
        public class BaseAPIModelForUser
        {
            string _userName;
            public string UserName
            {
                get => this._userName;
                set
                {
                    this._userName = value.Trim().ToLower().Replace("ı","i").Replace("ş","s").Replace("ü","u").Replace("ö","o").Replace("ğ","g");
                }
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
}
