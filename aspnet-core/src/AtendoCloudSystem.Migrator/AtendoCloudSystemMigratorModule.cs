using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AtendoCloudSystem.Configuration;
using AtendoCloudSystem.EntityFrameworkCore;
using AtendoCloudSystem.Migrator.DependencyInjection;

namespace AtendoCloudSystem.Migrator
{
    [DependsOn(typeof(AtendoCloudSystemEntityFrameworkModule))]
    public class AtendoCloudSystemMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AtendoCloudSystemMigratorModule(AtendoCloudSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AtendoCloudSystemMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AtendoCloudSystemConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AtendoCloudSystemMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
