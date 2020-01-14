using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.OtherNecessaryModels.ApiModels.PostModels
{
    public class BaseApiModelForPost
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
