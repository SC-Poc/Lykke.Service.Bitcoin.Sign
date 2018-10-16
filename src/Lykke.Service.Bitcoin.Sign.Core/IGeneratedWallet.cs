namespace Lykke.Service.Bitcoin.Sign.Core
{
    public interface IGeneratedWallet
    {
        string Address { get; }
        string PrivateKey { get; }
        string PubKey { get; set; }
    }
}
