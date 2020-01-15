namespace Article.Managers.Concretes
{
    #region Internal Usings
    using Base;
    using Abstracts;
    using Article.Models.EntitiesOfProjects.Entities;
    using Article.Models.OtherNecessaryModels.ApiModels.PostModels;
    using System.Collections.Generic;
    using Article.Common.Helpers;
    using System;
    using System.Linq;
    #endregion Internal Usings

    public class ManagerPost : BaseManager, IManagerPost
    {
        public bool CreatePost(NewPostAPIModel newPostAPIModel)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var addedItem = this.UnitOfWork.RepositoryOfPost.InsertItem(insertItem: new Post
                {
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CategoryId = newPostAPIModel.CategoryId,
                    Description = newPostAPIModel.Description,
                    Title = newPostAPIModel.Title,
                    UserId = newPostAPIModel.UserId
                });

                numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                if (numberOfRowsAffected > 0)
                {
                    this.UnitOfWork.CommitTransaction();
                    return true;
                }
                else
                {
                    this.UnitOfWork.RollbackTransaction();
                    return false;
                }
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            },
            finallyAndDo: () =>
            {
                this.UnitOfWork.Dispose();
            });
        }

        public bool DeletePost(int id)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var post = this.UnitOfWork.RepositoryOfPost.GetItem(id);
                this.UnitOfWork.RepositoryOfPost.DeleteItem(post);

                numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                if (numberOfRowsAffected > 0)
                {
                    this.UnitOfWork.CommitTransaction();
                    return true;
                }
                else
                {
                    this.UnitOfWork.RollbackTransaction();
                    return false;
                }
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            },
            finallyAndDo: () =>
            {
                this.UnitOfWork.Dispose();
            });
        }

        #region Select Methods
        public Post GetPost(int id)
        {
            return this.UnitOfWork.RepositoryOfPost.GetItem(id);
        }

        public List<Post> ListPost()
        {
            return this.UnitOfWork.RepositoryOfPost.GetAllItems();
        }

        public List<Post> ListActivePosts()
        {
            return this.UnitOfWork.RepositoryOfPost.GetAllActiveItems();
        }

        public List<Post> ListPostsByUserId(int userId)
        {
            return this.UnitOfWork.RepositoryOfPost.GetAllItems(x=>x.UserId == userId).ToList();
        }

        public List<Post> ListPostsByCategoryId(int categoryId)
        {
            return this.UnitOfWork.RepositoryOfPost.GetAllItems(x => x.CategoryId == categoryId).ToList();
        }
        #endregion Select Methods

        public bool UpdatePost(Post updatedPost)
        {
            int numberOfRowsAffected = default(int);

            return Tools.TryCatch<bool>(function: () =>
            {
                this.UnitOfWork.BeginTransaction();

                var post = this.UnitOfWork.RepositoryOfPost.GetItem(updatedPost.Id);
                post.ModifiedDate = DateTime.Now;
                post.Title = updatedPost.Title == null ? post.Title : updatedPost.Title;
                post.User = updatedPost.User == null ? post.User : updatedPost.User;
                post.UserId = updatedPost.UserId == 0 ? post.UserId : updatedPost.UserId;
                post.Description = updatedPost.Description == null ? post.Description : updatedPost.Description;
                post.CategoryId = updatedPost.CategoryId == 0 ? post.CategoryId : updatedPost.CategoryId;
                post.Category = updatedPost.Category == null ? post.Category : updatedPost.Category;

                this.UnitOfWork.RepositoryOfPost.DeleteItem(post);

                numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                if (numberOfRowsAffected > 0)
                {
                    this.UnitOfWork.CommitTransaction();
                    return true;
                }
                else
                {
                    this.UnitOfWork.RollbackTransaction();
                    return false;
                }
            },
            catchAndDo: (Exception exception) =>
            {
                throw exception;
            },
            finallyAndDo: () =>
            {
                this.UnitOfWork.Dispose();
            });
        }

        public bool UpdatePost(int id)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ManagerPost() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }

}
