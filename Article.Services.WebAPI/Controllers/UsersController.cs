using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#region Global Usings
using Article.Managers.Abstracts;
using Article.Models.OtherNecessaryModels.ApiModels.UserModels;
using Article.Models.EntitiesOfProjects.Entities;
#endregion

namespace Article.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IManagerUser managerUser;

        public UsersController(IManagerUser managerUser)
        {
            this.managerUser = managerUser;
        }

        /// <summary>
        /// Used to create a new user.
        /// Request Url: http://localhost:50115/api/users/new-user
        /// Dont forget to change your local url (You can find in Api properties - click to debug)
        /// Example Request
        /// {
        ///  "FirstName": "Yasin",
        ///  "LastName" : "Yenil",
        ///  "UserName" : "yasyen",
        ///  "UserPassword" : "123456"
        /// }
        /// </summary>
        /// <param name="newUserInformation"></param>
        /// <returns></returns>
        [HttpPost, Route(template: "new-user")]
        public IActionResult CreateUser([FromBody] NewUserAPIModel newUserInformation)
        {
            bool returnedResult = this.managerUser.CreateNewUser(newUserInformation: newUserInformation);
            if (returnedResult)
            {
                return Ok("Kullanici basarili bir sekilde eklendi");
            }
            else
            {
                return BadRequest(error: "Kullanici eklenemedi");
            }
        }


        [HttpGet, Route(template: "get-all-user")]
        public IActionResult GetAllUser()
        {
            //Aslında burada DTO kullanmak gerekli ve map işleminin yapılması gerekli
            List<User> users = this.managerUser.ListUser();

            return Ok(users);
        }

        /// <summary>
        /// Used to create a new user.
        /// Example Request
        /// {
        ///  "ID" : 1,
        ///  "FirstName": "Yasin",
        ///  "LastName" : "Yenil",
        ///  "UserName" : "yasyen",
        ///  "UserPassword" : "123456"
        /// }
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route(template: "update-user")]
        public IActionResult UpdateUser([FromBody] User user)
        {

            var users = this.managerUser.GetUser(user.Id);

            if (users != null)
            {
                bool returnedResult = this.managerUser.UpdateUser(user);
                if (returnedResult)
                {
                    return Ok("Kullanici basarili bir sekilde güncellendi.");
                }
                else
                {
                    return BadRequest(error: "Kullanici güncellenemedi.");
                }
            }
            else
            {
                return BadRequest(error: "Kullanıcı bulunamadı.");
            }
        }

        [HttpPost, Route(template: "delete-user/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            bool returnedResult = this.managerUser.DeleteUser(userId);
            if (returnedResult)
            {
                return Ok("Kullanici pasif hale getirildi.");
            }
            else
            {
                return BadRequest(error: "Kullanıcı silme işlemi başarısız.");
            }
        }
    }
}