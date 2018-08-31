using Common;
using Lykke.Service.Bitcoin.Sign.Core;
using Lykke.Service.Bitcoin.Sign.Models.Wallet;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.Bitcoin.Sign.Controllers
{
    [Route("api/[controller]")]
    public class WalletsController
    {
        private readonly IWalletGenerator _walletGenerator;

        public WalletsController(IWalletGenerator walletGenerator)
        {
            _walletGenerator = walletGenerator;
        }

        [HttpPost]
        public WalletCreationResponse CreateWallet()
        {
            var wallet = _walletGenerator.Generate();

            return new WalletCreationResponse
            {
                PublicAddress = wallet.Address,
                PrivateKey = wallet.PrivateKey,
                AddressContext = new AddressContextContract {PubKey = wallet.PubKey}.ToJson()
            };
        }
    }
}
