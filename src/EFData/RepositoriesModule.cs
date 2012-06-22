using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Domain.Repositories;
using Domain.Repositories.Authentication;
using EFData.Authentication;

namespace EFData
{
    public class RepositoriesModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FstClassRepository>().As<IFstClassRepository>().InstancePerDependency();
            builder.RegisterType<SndClassRepository>().As<ISndClassRepository>().InstancePerDependency();
            builder.RegisterType<NewsRepository>().As<INewsRepository>().InstancePerDependency();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerDependency();

        }
    }
}
