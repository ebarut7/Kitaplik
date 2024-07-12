using Kitaplik.DataAccess.Abstract;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.DependencyResolvers.Extension
{
    public static class Container
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IBookDal, BookDal>();
            services.AddScoped<INoteDal, NoteDal>();
            services.AddScoped<IShareSettingDal, ShareSettingDal>();
            services.AddScoped<IUserDal, UserDal>();
            return services;
        }
    }
}
