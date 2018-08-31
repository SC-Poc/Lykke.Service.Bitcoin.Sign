using System.Collections.Generic;
using NBitcoin;

namespace Lykke.Service.Bitcoin.Sign.Services.Sign
{
    public class TransactionInfo
    {
        public string TransactionHex { get; set; }

        public IEnumerable<Coin> UsedCoins { get; set; }
    }
}
