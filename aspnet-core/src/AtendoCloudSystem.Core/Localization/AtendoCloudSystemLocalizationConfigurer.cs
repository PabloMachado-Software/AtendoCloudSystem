using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AtendoCloudSystem.Localization
{
    public static class AtendoCloudSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AtendoCloudSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AtendoCloudSystemLocalizationConfigurer).GetAssembly(),
                        "AtendoCloudSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
