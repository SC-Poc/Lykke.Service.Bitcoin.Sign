using Lykke.HttpClientGenerator;

namespace Lykke.Service.Bitcoin.Sign.Client
{
    /// <summary>
    /// Bitcoin.Sign API aggregating interface.
    /// </summary>
    public class Bitcoin.SignClient : IBitcoin.SignClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to Bitcoin.Sign Api.</summary>
        public IBitcoin.SignApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public Bitcoin.SignClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<IBitcoin.SignApi>();
        }
    }
}
