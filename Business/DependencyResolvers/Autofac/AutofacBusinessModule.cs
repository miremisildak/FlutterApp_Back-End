using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfMarketDal>().As<IMarketDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<MarketManager>().As<IMarketService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<ProductImageManager>().As<IProductImageService>();


            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
