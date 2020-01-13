using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Article.Models.OtherNecessaryModels.DtoOfModels
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [MinLength(3, ErrorMessage = "Category must have at least 3 characters")]
        public string Name { get; set; }

        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
