using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        public List<Comment> TGetCommentsByArticle(int id);

        public List<Comment> TGetCommentsByAppUser(string id);

        public int TGetCommentCountByAppUser(string id);

        public List<Comment> TGetLast5Comment();
    }
}
