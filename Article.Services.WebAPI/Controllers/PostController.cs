using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.Managers.Abstracts;
using Article.Models.EntitiesOfProjects.Entities;
using Article.Models.OtherNecessaryModels.ApiModels.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IManagerPost managerPost;
        private readonly IManagerUser managerUser;
        private readonly IManagerCategory managerCategory;

        public PostController(IManagerPost managerPost, IManagerUser managerUser, IManagerCategory managerCategory)
        {
            this.managerPost = managerPost;
            this.managerUser = managerUser;
            this.managerCategory = managerCategory;
        }

        [HttpPost, Route("new-post")]
        public IActionResult CreateNewPost(NewPostAPIModel newPostAPIModel)
        {
            bool returnedResult = this.managerPost.CreatePost(newPostAPIModel: newPostAPIModel);
            if (returnedResult)
            {
                return Ok("Post basarili bir sekilde eklendi");
            }
            else
            {
                return BadRequest(error: "Post eklenemedi");
            }
        }

        [HttpGet, Route(template: "get-all-post")]
        public List<Post> GetAllPost()
        {
            //Aslında burada DTO kullanmak gerekli ve map işleminin yapılması gerekli
            List<Post> posts = this.managerPost.ListPost().ToList();

            return posts;
        }

        [HttpPost, Route(template: "update-post")]
        public IActionResult UpdatePost(Post post)
        {
            var isExistPost = this.managerPost.GetPost(post.Id);
            var isExistUser = this.managerUser.GetUser(post.UserId);
            var isExistCategory = this.managerCategory.GetCategory(post.CategoryId);

            string errorDetail = "";
            if (isExistPost == null)
            {
                errorDetail += "Post bulunamadı. ";
            }
            if (isExistUser == null)
            {
                errorDetail += " Kullanıcı bulunamadı. ";
            }
            if (isExistCategory == null)
            {
                errorDetail += " Kategori bulunamadı.";
            }

            if (isExistPost != null || isExistUser != null || isExistCategory != null)
            {
                bool returnedResult = this.managerPost.UpdatePost(post);
                if (returnedResult)
                {
                    return Ok("Makale basarili bir sekilde güncellendi");
                }
                else
                {
                    return BadRequest(error: "Makale güncellenemedi");
                }
            }
            else
            {
                return BadRequest(error: errorDetail);
            }
        }

        [HttpPost, Route(template: "delete-post/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            bool returnedResult = this.managerPost.DeletePost(postId);
            if (returnedResult)
            {
                return Ok("Post pasif hale getirildi.");
            }
            else
            {
                return BadRequest(error: "Post silme işlemi başarısız.");
            }
        }


    }
}