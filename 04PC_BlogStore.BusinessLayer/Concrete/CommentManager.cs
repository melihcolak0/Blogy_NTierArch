using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(int id)
        {
            _commentDal.Delete(id);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public int TGetCommentCountByAppUser(string id)
        {
            return _commentDal.GetCommentCountByAppUser(id);
        }

        public List<Comment> TGetCommentsByAppUser(string id)
        {
            return _commentDal.GetCommentsByAppUser(id);
        }

        public List<Comment> TGetCommentsByArticle(int id)
        {
            return _commentDal.GetCommentsByArticle(id);
        }

        public List<Comment> TGetLast5Comment()
        {
            return _commentDal.GetLast5Comment();
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
