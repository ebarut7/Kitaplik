using Autofac;
using Kitaplik.Business.Abstract;
using Kitaplik.Business.Concrete;
using Kitaplik.DataAccess.Abstract;
using Kitaplik.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.DependencyResolvers.AutoFac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShareSettingManager>().As<IShareSettingService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<NoteManager>().As<INoteService>();
            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            base.Load(builder);
        }
    }
}
