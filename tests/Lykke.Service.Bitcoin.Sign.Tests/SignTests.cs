using System.Collections.Generic;
using System.Linq;
using Lykke.Service.Bitcoin.Sign.Services.Sign;
using NBitcoin;
using NBitcoin.JsonConverters;
using Xunit;

namespace Lykke.Service.Bitcoin.Sign.Tests
{
    public class SignTests
    {
        private void TestTransactionSign(BitcoinAddress bitcoinAddress, Key key1, Network network1)
        {
            var spentTx = network1.Consensus.ConsensusFactory.CreateTransaction();
            spentTx.Outputs.Add(new TxOut("1", bitcoinAddress));

            var builder = new TransactionBuilder();
            builder.AddCoins(spentTx);
            builder.Send(bitcoinAddress, "0.001");
            builder.SendFees("0.001");
            builder.SetChange(bitcoinAddress);
            builder.AddKeys(key1);

            var signedTx = builder.BuildTransaction(true);
            AssertCorrectlySigned(signedTx, bitcoinAddress.ScriptPubKey, spentTx.Outputs[0].Value);

            var unsignedTx = builder.BuildTransaction(false);
            var txInfo = new TransactionInfo
            {
                TransactionHex = unsignedTx.ToHex(),
                UsedCoins = builder.FindSpentCoins(unsignedTx).OfType<Coin>()
            };


            var signer = new TransactionSigningService(network1);
            var signedTx2 = signer.Sign(Serializer.ToString(txInfo), new List<string> {key1.ToString(network1)});

            Assert.Equal(signedTx.ToHex(), signedTx2.TransactionHex);
        }

        private static void AssertCorrectlySigned(Transaction tx, Script scriptPubKey, Money money)
        {
            for (var i = 0; i < tx.Inputs.Count; i++)
                Assert.True(Script.VerifyScript(scriptPubKey, tx, 0, money, ScriptVerify.Standard, SigHash.All));
        }

        [Fact]
        public void Can_Sign_Mainnet_transaction()
        {
            var network = Network.Main;

            var key = new Key();
            var addr = key.PubKey.WitHash.ScriptPubKey.Hash.GetAddress(network);
            TestTransactionSign(addr, key, network);
        }

        [Fact]
        public void Can_Sign_PubKeyHash_Mainnet_transaction()
        {
            var network = Network.Main;
            var key = new Key();
            var addr = key.PubKey.GetAddress(network);
            TestTransactionSign(addr, key, network);
        }

        [Fact]
        public void Can_Sign_Segwit_Mainnet_transaction()
        {
            var network = Network.Main;
            var key = new Key();
            var addr = key.PubKey.WitHash.GetAddress(network);
            TestTransactionSign(addr, key, network);
        }


        [Fact]
        public void Can_Sign_SegwitOver2Sh_Testnet_transaction()
        {
            var network = Network.TestNet;
            var key = new Key();
            var addr = key.PubKey.WitHash.ScriptPubKey.Hash.GetAddress(network);
            TestTransactionSign(addr, key, network);
        }
    }
}
