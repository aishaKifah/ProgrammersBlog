using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using programmersBlog.Data.Abstract;
using programmersBlog.Data.Concrete;
using programmersBlog.Data.Concrete.EntityFramework.Contexts;
using programmersBlog.Entities.Concrete;
using programmersBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Services.ServiceCollectionExtemsions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            // bu class mvc katmani ve service katmani arasinda bir kopru .
            serviceCollection.AddDbContext<ProgrammerBlogContext>(options=> options.UseSqlServer(connectionString));
            serviceCollection.AddIdentity<User, Role>(options =>
            { 
                // user password options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                //user username amd email options 
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;


                }).AddEntityFrameworkStores<ProgrammerBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManeger>();
            return serviceCollection;
        }
    }
}
