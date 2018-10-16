using System.Collections.Generic;

namespace Lykke.Service.Bitcoin.Sign.Core.Sign
{
    public interface ITransactionSigningService
    {
        ISignResult Sign(string transactionContext, IEnumerable<string> privateKeys);
    }
}
