using System.Runtime.Serialization;

namespace Lykke.Service.Bitcoin.Sign.Models.Sign
{
    [DataContract]
    public class SignOkTransactionResponce
    {
        [DataMember(Name = "signedTransaction")]
        public string SignedTransaction { get; set; }
    }
}
