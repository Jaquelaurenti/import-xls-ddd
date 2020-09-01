using Autofac;
using AutoMapper;
using ImportSpreadsheet.Application;
using ImportSpreadsheet.Application.Interfaces;
using ImportSpreadsheet.Application.Mappers;
using ImportSpreadsheet.Domain.Core.Interfaces.Repositorys;
using ImportSpreadsheet.Domain.Core.Interfaces.Services;
using ImportSpreadsheet.Domain.Services;
using ImportSpreadsheet.Infrastructure.Data.Repositorys;

namespace ImportSpreadsheet.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceImport>().As<IApplicationServiceImport>();
            builder.RegisterType<ServiceImport>().As<IServiceImport>();



            builder.RegisterType<RepositoryImport>().As<IRepositoryImport>();


            builder.Register(ctx => new MapperConfiguration(cfg =>
            {


                cfg.AddProfile(new DtoToModelMappingImport());
                cfg.AddProfile(new ModelToDtoMappingImport());

            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }

}