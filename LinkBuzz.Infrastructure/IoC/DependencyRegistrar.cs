
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using Autofac;
using LinkBuzz.Domain.InterfaceRepositories;
using LinkBuzz.Domain.Misc;
using LinkBuzz.Infrastructure.Behaviors;
using LinkBuzz.Infrastructure.DataContexts;
using LinkBuzz.Infrastructure.ImplementRepositories;
using LinkBuzz.Infrastructure.Logging;
using LinkBuzz.Infrastructure.Misc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Infrastructure.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(LoggerAdapter<>)).As(typeof(IAppLogger<>)).InstancePerDependency();

            builder.RegisterType<AppDbContextSeeding>();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();


            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }

        public int Order => 1;
    }
}
