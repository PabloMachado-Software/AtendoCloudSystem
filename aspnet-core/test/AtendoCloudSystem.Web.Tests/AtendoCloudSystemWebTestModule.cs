using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AtendoCloudSystem.EntityFrameworkCore;
using AtendoCloudSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AtendoCloudSystem.Web.Tests
{
    [DependsOn(
        typeof(AtendoCloudSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AtendoCloudSystemWebTestModule : AbpModule
    {
        public AtendoCloudSystemWebTestModule(AtendoCloudSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AtendoCloudSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AtendoCloudSystemWebMvcModule).Assembly);
        }
    }
}