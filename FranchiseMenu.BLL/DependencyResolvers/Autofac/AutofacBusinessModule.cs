

using Autofac;
using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.BLL.Concrete;
using FranchiseMenu.CORE.Security;
using FranchiseMenu.DAL.Abstract;
using FranchiseMenu.DAL.Concrete;
using Microsoft.AspNetCore.Http;

namespace FranchiseMenu.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FoodManager>().As<IFoodService>();
            builder.RegisterType<EfFoodDal>().As<IFoodDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<EfAdminDal>().As<IAdminDal>();

            builder.RegisterType<TokenHelper>().As<ITokenHelper>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
        }
    }
}
