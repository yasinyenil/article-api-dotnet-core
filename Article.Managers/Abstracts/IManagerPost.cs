using Article.Models.EntitiesOfProjects.Entities;
using Article.Models.OtherNecessaryModels.ApiModels.PostModels;
using Article.Models.OtherNecessaryModels.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Managers.Abstracts
{
    public interface IManagerPost : IDisposable
    {

        bool CreatePost(NewPostAPIModel newPostAPIModel);

        List<Post> ListPost();

        Post GetPost(int id);

        bool UpdatePost(Post post);

        bool DeletePost(int id);
    }
}
