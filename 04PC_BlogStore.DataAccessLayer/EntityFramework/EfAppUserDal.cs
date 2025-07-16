using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Context;
using _04PC_BlogStore.DataAccessLayer.Repositories;
using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly BlogContext _context;

        public EfAppUserDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public int GetAppUserCount()
        {
            return _context.Users.Count();
        }
    }
}
