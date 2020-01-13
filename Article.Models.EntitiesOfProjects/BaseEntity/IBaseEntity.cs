using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.EntitiesOfProjects.BaseEntity
{
    public interface IBaseEntity
    {
         int Id { get; set; }

         DateTime CreationDate { get; set; }

         Nullable<DateTime> ModifiedDate { get; set; }

         bool IsActive { get; set; }
    }
}
