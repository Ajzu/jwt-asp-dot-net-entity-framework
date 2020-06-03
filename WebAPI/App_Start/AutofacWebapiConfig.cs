using Autofac;
using Autofac.Integration.WebApi;
using Repositorie.Infrastructure;
using Service.Interface;
using Service.Service;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace WebAPI.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
          
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DataBaseContext>().As<DbContext>().InstancePerRequest();

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>)).InstancePerRequest();


            // Register a logger service to be used by the controller and middleware.
            builder.Register(c => new UserOldService()).As<IUserOldService>().InstancePerRequest();
            builder.Register(c => new RefreshTokenService()).As<IRefreshTokenService>().InstancePerRequest();
            builder.Register(c => new ClientService()).As<IClientService>().InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}