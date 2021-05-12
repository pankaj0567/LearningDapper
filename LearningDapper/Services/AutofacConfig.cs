using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Dapper.Data;
using Dapper.Data.Repositories.ConcreteClasses;
using Dapper.Data.Repositories.Interface;

namespace LearningDapper.Services
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterGeneric(typeof(DapperRepository<>)).As(typeof(IRepository<>)).SingleInstance();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
            builder.RegisterType<Db>().As<IDb>().SingleInstance();
            builder.RegisterType<DbContext>().As<IDbContext>().SingleInstance();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
