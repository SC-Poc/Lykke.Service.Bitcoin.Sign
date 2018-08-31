using JetBrains.Annotations;

namespace Lykke.Service.Bitcoin.Sign.Client
{
    /// <summary>
    /// Bitcoin.Sign client interface.
    /// </summary>
    [PublicAPI]
    public interface IBitcoin.SignClient
    {
        /// <summary>Application Api interface</summary>
        IBitcoin.SignApi Api { get; }
    }
}
