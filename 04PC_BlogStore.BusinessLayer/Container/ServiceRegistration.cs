using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.BusinessLayer.Concrete;
using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Context;
using _04PC_BlogStore.DataAccessLayer.EntityFramework;
using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.Container
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {          
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddDbContext<BlogContext>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<BlogContext>();

            return services;
        }
    }
}
