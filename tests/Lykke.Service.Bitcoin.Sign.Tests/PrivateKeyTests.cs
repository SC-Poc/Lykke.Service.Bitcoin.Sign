using Lykke.Service.Bitcoin.Sign.Services.Wallet;
using NBitcoin;
using Xunit;

namespace Lykke.Service.Bitcoin.Sign.Tests
{
    public class PrivateKeyTests
    {
        [Fact]
        public void CanGenerateValidPrivateKey()
        {
            var network = Network.Main;

            var generator = new WalletGenerator(network);

            var generatedWallet = generator.Generate();

            var key = Key.Parse(generatedWallet.PrivateKey, network);
            var addressFromKey = key.PubKey.WitHash.ScriptPubKey.Hash.GetAddress(network).ToString();

            Assert.True(generatedWallet.Address == addressFromKey);
            Assert.True(generatedWallet.PubKey == key.PubKey.ToHex());
            Assert.True(generatedWallet.PrivateKey == key.ToString(network));
        }
    }
}
