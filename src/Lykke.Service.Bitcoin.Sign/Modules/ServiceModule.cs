using Autofac;
using Lykke.Service.Bitcoin.Sign.Core;
using Lykke.Service.Bitcoin.Sign.Core.Sign;
using Lykke.Service.Bitcoin.Sign.Services.Sign;
using Lykke.Service.Bitcoin.Sign.Services.Wallet;
using Lykke.Service.Bitcoin.Sign.Settings;
using Lykke.SettingsReader;
using NBitcoin;

namespace Lykke.Service.Bitcoin.Sign.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<BitcoinSignSettings> _settings;

        public ServiceModule(IReloadingManager<AppSettings> settings)
        {
            _settings = settings.Nested(o => o.BitcoinSignService);
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterNetwork(builder);

            builder.RegisterType<TransactionSigningService>().As<ITransactionSigningService>();
            builder.RegisterType<WalletGenerator>().As<IWalletGenerator>();
        }

        private void RegisterNetwork(ContainerBuilder builder)
        {
            builder.RegisterInstance(Network.GetNetwork(_settings.CurrentValue.Network.ToLower())).As<Network>();
        }
    }
}
