using Autofac;
using LinkBuzz.Domain.Misc;
using LinkBuzz.Infrastructure.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Infrastructure.IoC
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
