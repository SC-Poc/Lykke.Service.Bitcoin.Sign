using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.Bitcoin.Sign.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public BitcoinSignSettings BitcoinSignService { get; set; }
    }
}
