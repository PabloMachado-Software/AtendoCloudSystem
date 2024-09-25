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
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "b5a2790f84ae4ba7872928fb2cbbe102";
    }
}
