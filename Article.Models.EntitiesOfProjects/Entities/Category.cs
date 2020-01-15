using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.EntitiesOfProjects.Entities
{
    #region Internal usings
    using BaseEntity;
    using System.ComponentModel.DataAnnotations;

    #endregion Internal usings

    public partial class Category : IBaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public int Id { get; set ; }
        public DateTime CreationDate { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
        public bool IsActive { get ; set ; }
    }
}
