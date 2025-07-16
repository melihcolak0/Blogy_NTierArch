using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetCommentsByArticle(int id);

        public List<Comment> GetCommentsByAppUser(string id);

        public int GetCommentCountByAppUser(string id);

        public List<Comment> GetLast5Comment();
    }
}
