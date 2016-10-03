using Harvest.Net.Models.Interfaces;
using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// OAuth response model given by the authentication of the harvest API.
    /// </summary>
    public class OAuth : IOAuth
    {
        /// <summary>
        /// Access token given by the API.
        /// </summary>
        [SerializeAs(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Token to refresh the access token.
        /// </summary>
        [SerializeAs(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Time left til expiration date of the token.
        /// </summary>
        [SerializeAs(Name = "expires_in")]
        public int? ExpiresIn { get; set; }

        /// <summary>
        /// Type of the token.
        /// Example:
        /// <example>
        /// bearer
        /// </example>
        /// </summary>
        [SerializeAs(Name = "token_type")]
        public string TokenType { get; set; }
    }
}
