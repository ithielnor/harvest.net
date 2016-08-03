using Harvest.Net.Models.Interfaces;
using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    public class OAuth : IOAuth
    {
        [SerializeAs(Name = "access_token")]
        public string AccessToken { get; set; }

        [SerializeAs(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        [SerializeAs(Name = "expires_in")]
        public int? ExpiresIn { get; set; }

        [SerializeAs(Name = "token_type")]
        public string TokenType { get; set; }
    }
}
