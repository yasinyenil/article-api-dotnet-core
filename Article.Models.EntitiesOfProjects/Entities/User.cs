using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.EntitiesOfProjects.Entities
{
    #region Internal usings
    using BaseEntity;

    #endregion Internal usings

    public partial class User : IBaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int Id { get; set ; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
