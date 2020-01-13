using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Article.Models.OtherNecessaryModels.DtoOfModels
{
    public class PostDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        [MinLength(3, ErrorMessage = "Title must have at least 3 characters!")]
        public string Title { get; set; }

        [MinLength(10, ErrorMessage = "Description must have at least 10 characters!")]
        public string Description { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public UserDTO User { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
