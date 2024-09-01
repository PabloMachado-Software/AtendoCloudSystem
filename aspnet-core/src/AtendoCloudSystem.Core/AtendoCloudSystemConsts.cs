using AtendoCloudSystem.Debugging;

namespace AtendoCloudSystem
{
    public class AtendoCloudSystemConsts
    {
        public const string LocalizationSourceName = "AtendoCloudSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "1cbe8f715d064f7288dbfd845b4cf207";
    }
}
