using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.EntitiesOfProjects.Entities
{
    #region Internal usings
    using BaseEntity;

    #endregion Internal usings

    public partial class Post : IBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
    }
}
