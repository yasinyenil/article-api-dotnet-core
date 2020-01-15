using Article.Models.EntitiesOfProjects.Entities;
using Article.Models.OtherNecessaryModels.ApiModels.CategoryModels;
using System;
using System.Collections.Generic;

namespace Article.Managers.Abstracts
{
    public interface IManagerCategory :IDisposable
    {
        bool CreateNewCategory(NewCategoryAPIModel newCategoryAPIModel);

        List<Category> ListCategory();

        Category GetCategory(int id);

        bool UpdateCategory(Category category);

        bool DeleteCategory(int id);
    }
}
