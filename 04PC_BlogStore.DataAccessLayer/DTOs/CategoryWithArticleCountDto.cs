using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.DTOs
{
    public class CategoryWithArticleCountDto
    {
        public string CategoryName { get; set; }

        public int ArticleCount { get; set; }
    }
}
