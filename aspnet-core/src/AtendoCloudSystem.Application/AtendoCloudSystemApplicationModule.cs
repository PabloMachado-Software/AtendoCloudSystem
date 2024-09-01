using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AtendoCloudSystem.Authorization;

namespace AtendoCloudSystem
{
    [DependsOn(
        typeof(AtendoCloudSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AtendoCloudSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AtendoCloudSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AtendoCloudSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
