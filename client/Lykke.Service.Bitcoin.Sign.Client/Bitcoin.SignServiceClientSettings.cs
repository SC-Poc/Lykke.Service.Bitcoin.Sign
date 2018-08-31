using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.Bitcoin.Sign.Client 
{
    /// <summary>
    /// Bitcoin.Sign client settings.
    /// </summary>
    public class Bitcoin.SignServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
