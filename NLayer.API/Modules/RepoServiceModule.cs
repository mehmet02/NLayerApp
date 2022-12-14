using System.Reflection;
using Autofac;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using Module = Autofac.Module;

namespace NLayer.API.Modules;

public class RepoServiceModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssemmbly = Assembly.GetAssembly(typeof(AppDbContext));
        var serviceAssemmbly = Assembly.GetAssembly(typeof(MapProfile));

        builder.RegisterAssemblyTypes(apiAssembly, repoAssemmbly,serviceAssemmbly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(apiAssembly, repoAssemmbly,serviceAssemmbly).Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}