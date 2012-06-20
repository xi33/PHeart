using Autofac;
using Domain.Authentication.Internal;

namespace Domain.Authentication
{
    public class AuthenticationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FormsAuthenticator>().As<IAuthenticator>().InstancePerLifetimeScope();
            builder.RegisterType<FormsMembershipProvider>().As<IMembershipProvider>().InstancePerLifetimeScope();
            builder.RegisterType<FormsRoleProvider>().As<IRoleProvider>().InstancePerLifetimeScope();

        }
    }
}