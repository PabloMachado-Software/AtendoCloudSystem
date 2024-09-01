using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AtendoCloudSystem.Configuration;

namespace AtendoCloudSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(AtendoCloudSystemWebCoreModule))]
    public class AtendoCloudSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AtendoCloudSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AtendoCloudSystemWebHostModule).GetAssembly());
        }
    }
}
