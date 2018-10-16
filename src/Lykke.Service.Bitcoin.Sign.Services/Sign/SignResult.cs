using Lykke.Service.Bitcoin.Sign.Core.Sign;

namespace Lykke.Service.Bitcoin.Sign.Services.Sign
{
    internal class SignResult : ISignResult
    {
        public string TransactionHex { get; private set; }


        public static SignResult Ok(string signedHex)
        {
            return new SignResult
            {
                TransactionHex = signedHex
            };
        }
    }
}
