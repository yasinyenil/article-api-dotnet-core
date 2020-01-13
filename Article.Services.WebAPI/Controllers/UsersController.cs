using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#region Global Usings
using Article.Managers.Abstracts;
using Article.Models.OtherNecessaryModels.ApiModels.UserModels;
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




    }
}