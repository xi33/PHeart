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
            //PHeartDbContext context=new PHeartDbContext();

            builder.RegisterType<FstClassRepository>().As<IFstClassRepository>().InstancePerDependency();
            builder.RegisterType<SndClassRepository>().As<ISndClassRepository>().InstancePerDependency();
            builder.RegisterType<NewsRepository>().As<INewsRepository>().InstancePerDependency();
            //builder.Register(_ => new FstClassRepository(context)).As<IFstClassRepository>().InstancePerDependency();
            //builder.Register(_ => new SndClassRepository(context)).As<ISndClassRepository>().InstancePerDependency();
            //builder.Register(_ => new NewsRepository(context)).As<INewsRepository>().InstancePerDependency();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerDependency();
            //builder.Register(_ => new UserRepository(context)).As<IUserRepository>().InstancePerDependency();
            //builder.Register(_ => new RoleRepository(context)).As<IRoleRepository>().InstancePerDependency();

        }
    }
}
