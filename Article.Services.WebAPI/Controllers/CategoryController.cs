using Article.Managers.Abstracts;
using Article.Models.EntitiesOfProjects.Entities;
using Article.Models.OtherNecessaryModels.ApiModels.CategoryModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Article.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IManagerCategory managerCategory;

        public CategoryController(IManagerCategory managerCategory)
        {
            this.managerCategory = managerCategory;
        }


        [HttpPost, Route("new-category")]
        public IActionResult CreateNewCategory(NewCategoryAPIModel newCategoryAPIModel)
        {
            bool returnedResult = this.managerCategory.CreateNewCategory(newCategoryAPIModel: newCategoryAPIModel);
            if (returnedResult)
            {
                return Ok("Kategori basarili bir sekilde eklendi");
            }
            else
            {
                return BadRequest(error: "Kategori eklenemedi");
            }
        }

        [HttpGet, Route(template: "get-all-category")]
        public List<Category> GetAllUser()
        {
            //Aslında burada DTO kullanmak gerekli ve map işleminin yapılması gerekli
            List<Category> users = this.managerCategory.ListCategory().ToList();

            return users;
        }

        [HttpPost, Route(template: "update-category/{categoryId}")]
        public IActionResult UpdateCategory(int categoryId)
        {
            bool returnedResult = this.managerCategory.UpdateCategory(categoryId);
            if (returnedResult)
            {
                return Ok("Kullanici basarili bir sekilde güncellendi");
            }
            else
            {
                return BadRequest(error: "Kullanici güncellenemedi");
            }
        }

        [HttpPost, Route(template: "delete-category/{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            bool returnedResult = this.managerCategory.DeleteCategory(categoryId);
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